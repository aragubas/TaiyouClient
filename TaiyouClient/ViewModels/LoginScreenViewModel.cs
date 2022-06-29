using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using ReactiveUI;
using TaiyouClient.Models.Request;
using TaiyouClient.Models.Response;
using TaiyouClient.Views;

namespace TaiyouClient.ViewModels
{
    public class LoginScreenViewModel : ViewModelBase
    {
        string _titleText = "Login";
        public string TitleText
        {
            get => _titleText;
            set => this.RaiseAndSetIfChanged(ref _titleText, value);
        }

        string _loginButtonText = "Sign In";
        public string LoginButtonText
        {
            get => _loginButtonText;
            set => this.RaiseAndSetIfChanged(ref _loginButtonText, value);
        }

        #region Input Fields
        // Email Field
        string _emailField = "";
        public string EmailField
        {
            get => _emailField;
            set => this.RaiseAndSetIfChanged(ref _emailField, value);
        }
        
        // Username Field
        string _usernameField = "";
        public string UsernameField
        {
            get => _usernameField;
            set => this.RaiseAndSetIfChanged(ref _usernameField, value);
        }

        // Password Field
        string _passwordField = "";
        public string PasswordField
        {
            get => _passwordField;
            set => this.RaiseAndSetIfChanged(ref _passwordField, value);
        }

        // Confirm Password Field
        string _confirmPasswordField = "";
        public string ConfirmPasswordField
        {
            get => _confirmPasswordField;
            set => this.RaiseAndSetIfChanged(ref _confirmPasswordField, value);
        }
        #endregion

        #region Message
        bool _messageVisible = false;
        public bool MessageVisible
        {
            get => _messageVisible;
            set => this.RaiseAndSetIfChanged(ref _messageVisible, value);
        }

        bool _messageButtonsVisible = false;
        public bool MessageButtonsVisible
        {
            get => _messageButtonsVisible;
            set => this.RaiseAndSetIfChanged(ref _messageButtonsVisible, value);
        }

        string _messageTitle = "message_title";
        public string MessageTitle
        {
            get => _messageTitle;
            set => this.RaiseAndSetIfChanged(ref _messageTitle, value);
        }

        string _messageText = "message_text";
        public string MessageText
        {
            get => _messageText;
            set => this.RaiseAndSetIfChanged(ref _messageText, value);
        }
        #endregion

        public bool _isRegisterMode = false;
        public bool IsRegisterMode
        {
            get => _isRegisterMode;
            set => this.RaiseAndSetIfChanged(ref _isRegisterMode, value);
        }
        
        bool FieldsValid()
        {
            Regex checkGex = new Regex(@"^[a-zA-Z]");
            
            if (IsRegisterMode)
            {
                bool RegisterUsernameValid = UsernameField.Length >= 4 && UsernameField != "" && checkGex.IsMatch(UsernameField);
                bool RegisterEmailValid = EmailField.Length >= 4 && EmailField != "";
                bool RegisterPasswordValid = PasswordField.Length >= 4 && PasswordField != "" && PasswordField == ConfirmPasswordField;

                return RegisterUsernameValid && RegisterEmailValid && RegisterPasswordValid;
            }

            bool EmailValid = EmailField.Length >= 4 && EmailField != "";
            bool PasswordValid = PasswordField.Length >= 4 && PasswordField != "";

            return EmailValid && PasswordValid;
        }

        void MessageBox(string Title, string Text = "")
        {
            MessageVisible = true;
            MessageText = Text;
            MessageTitle = Title;
            MessageButtonsVisible = Text != "";

        }

        async void DoCreateUser()
        {
            CreateUserRequest requestModel = new CreateUserRequest(UsernameField, EmailField, PasswordField);

            HttpResponseMessage response = await API.client.PostAsync("http://localhost:3314/user", new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                GenericResponse data = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                
                if (data.Message == "invalid_data")
                {
                    MessageBox("Invalid Data", "Email, Username or Password contains invalid data.");
                    return;
                }

                if (data.Message == "user_already_exists")
                {
                    MessageBox("Username or Email Address taken", "A user with specified Username or Email already exists.");
                    return;
                }
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                GetMeResponse data = JsonConvert.DeserializeObject<GetMeResponse>(await response.Content.ReadAsStringAsync());

                MessageBox("Loading Dashboard...");
                SetUpCredentials(data);
                return;
            }
        }

        void SetUpCredentials(GetMeResponse getMe)
        {
            // Set CurrentUserModel
            API.CurrentUser.Username = getMe.Username;
            API.CurrentUser.UserID = getMe.UserID;
            API.CurrentUser.AccessToken = getMe.AccessToken;

            // Store user credentials
            API.UpdateStoredUser();

            // Change the view
            MainWindowViewModel.Instance.CurrentContent = new MainArea();
        }

        public void RegisterButtonClick()
        {
            if (!IsRegisterMode)
            {
                IsRegisterMode = true;
                TitleText = "Register";
                LoginButtonText = "Sign In Instead";

                // TODO: When enabling "register mode"

                return;
            }

            MessageBox("Creating User...");
            DoCreateUser();
        }

        void HideMessage()
        {
            MessageTitle = "";
            MessageText = "";
            MessageVisible = false;
        }

        public void MessageOkButton() => HideMessage();

        async void DoLogin()
        {
            HttpRequestMessage requestData = new HttpRequestMessage(HttpMethod.Get, "http://localhost:3314/user");
            requestData.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{EmailField}:{PasswordField}")));

            try
            {
                HttpResponseMessage httpResponse = await API.client.SendAsync(requestData);
                string bodyString = await httpResponse.Content.ReadAsStringAsync();
            
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    GenericResponse response = JsonConvert.DeserializeObject<GenericResponse>(bodyString);
                
                    if (response.Message == "invalid_credentials")
                    {
                        MessageBox("Email or Password incorrect", "Please try again.");
                        return;
                    }

                    if (response.Message == "missing_credentials")
                    {
                        MessageBox("Missing Credentials", "Your client may be outdated or that's a bug.\nPlease let us know about that");
                        return;
                    }

                    if (response.Message == "banned")
                    {
                        MessageBox("Your account has been banned.", "Please check the email address associated with your account.\nIf you think that was a mistake, please contact our support.");
                        return;
                    }
                }

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    GetMeResponse data = JsonConvert.DeserializeObject<GetMeResponse>(bodyString);

                    MessageBox("Loading Dashboard...");
                    SetUpCredentials(data);
                    return;
                }

            } catch (HttpRequestException exc)
            {
                MessageBox("Error while connecting to Taiyou Service", exc.Message);

            }
        }

        public void LoginButtonClick()
        {
            if (IsRegisterMode)
            {
                IsRegisterMode = false;
                TitleText = "Login";
                LoginButtonText = "Sign In";
                return;
            }

            // TODO: Check textboxes input and send GET_ME request to HTTP API
            MessageBox("Logging In...");

            DoLogin();
        }

        public LoginScreenViewModel()
        {
            
        }
        
    }
}
