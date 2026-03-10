
using SudMauiApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace SudMauiApp.Models
{
    public class FarmApiService
    {
        private readonly HttpClient _httpClient;

        public FarmApiService()
        {
            _httpClient = new HttpClient
            {

                BaseAddress = new Uri("http://10.112.0.165:5000/api/")
                //BaseAddress = new Uri("http://127.0.0.1:5202/api/")
                //BaseAddress = new Uri("http://4.198.108.221:80/api/")
            };
        }

        public async Task<string> UserLoginCheck()
        {
            var token = await SecureStorage.GetAsync("jwt_token");

            if (string.IsNullOrEmpty(token))
            {
                return "User not logged in. Please login";
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync("Farm/LoginValidationCheck");

            if (response.IsSuccessStatusCode)
            {
                return "Login Successful";
            }
            else
            {
                return "Login Expired. Please Login";
            }
        }

        public async Task<LoginResponse> UserLogin(MultipartFormDataContent content)
        {         
            HttpResponseMessage response = await _httpClient.PostAsync("account/login", content);

            string result = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var LoginResult = JsonSerializer.Deserialize<LoginResponse>(result);
                //System.Diagnostics.Debug.WriteLine("Login success: " + result);

                await SecureStorage.SetAsync("jwt_token", LoginResult.token);
                await SecureStorage.SetAsync("user_identity", LoginResult.identity);
                await SecureStorage.SetAsync("user_guid", LoginResult.userId);

                return LoginResult;
            }
            else
            {
                throw new Exception($"Login failed. \n\n {result}");
            }
        }


        public async Task<object> Registration(MultipartFormDataContent content)
        {
            HttpResponseMessage response = await _httpClient.PostAsync("account/register", content);

            try
            {
                var result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<RegistrationResponse>(result);
                }
                else
                {
                    var validation = JsonSerializer.Deserialize<ErrorResponse>(result);

                    if (validation?.errors != null)
                        return validation;

                    else if (validation?.error_msg != null)
                        return validation.error_msg;
                   
                    return new ErrorResponse 
                    {
                        error_msg = "Unknown error occurred."
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Registration Failed. {ex.Message}");
            }
        }

        public async Task<object> ConfirmEmail(MultipartFormDataContent content)
        {
            HttpResponseMessage response = await _httpClient.PostAsync("account/ConfirmEmail", content);

            try
            {
                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return result;
                }
                else
                {
                    return "Registration Error.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error. Registration Failed. {ex.Message}.");
            }
        }


        public async Task<object> ForgotPassword(MultipartFormDataContent content)
        {
            HttpResponseMessage response = await _httpClient.PostAsync("account/forgotpassword", content);

            try
            {
                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<RegistrationResponse>(result);
                }
                else
                {
                    var validation = JsonSerializer.Deserialize<ErrorResponse>(result);

                    if (validation?.errors != null)
                        return validation;

                    else if (validation?.error_msg != null)
                        return validation.error_msg;

                    return new ErrorResponse
                    {
                        error_msg = "Unknown error occurred."
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error. Password Reset Failed. {ex.Message}.");
            }
        }


        public async Task<object> VerifyEmailAddress(MultipartFormDataContent content)
        {
            HttpResponseMessage response = await _httpClient.PostAsync("account/useremailverification", content);

            try
            {
                var result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<RegistrationResponse>(result);
                }
                else
                {
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Registration Failed. {ex.Message}");
            }
        }

        public async Task<object> ResetPassword(MultipartFormDataContent content)
        {
            HttpResponseMessage response = await _httpClient.PostAsync("account/ChangePassword", content);

            try
            {
                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return result;
                }
                else
                {
                     var validation = JsonSerializer.Deserialize<ErrorResponse>(result);

                     if (validation?.errors != null)
                         return validation;

                     else if (validation?.error_msg != null)
                        return new ErrorResponse
                        {
                            error_msg = validation.error_msg,
                        };

                    return new ErrorResponse
                    {                        
                        error_msg = result.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error. Password Reset Failed. {ex.Message}.");
            }
        }

        public async Task<List<FishData>> GetFishData()
        {
            List<FishData> _fddata = new List<FishData>();

            HttpResponseMessage response = await _httpClient.GetAsync("Farm");

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                _fddata = JsonSerializer.Deserialize<List<FishData>>(result);
            }

            return _fddata;
        }

        public async Task<List<FishData>> SearchDistrict(string district)
        {
            List<FishData> _fddata = new List<FishData>();

            HttpResponseMessage response = await _httpClient.GetAsync("Farm/district/" + district);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                _fddata = JsonSerializer.Deserialize<List<FishData>>(result);
            }

            return _fddata;
        }

        public async Task<FishData> GetSingleFishData(int id)
        {
            //List<FishData> SingleCus_FD = new List<FishData>();

            HttpResponseMessage response = await _httpClient.GetAsync("Farm/" + id);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<FishData>(result);

                //return SingleCus_FD;
            }
        }

        public async Task<string> GetAdsByUserGuid(string userguid)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Farm/getadsusinguserguid/" + userguid);
            
            if (!response.IsSuccessStatusCode)
            {
                return "Unknown Error Occured.";
            }
            else
            {
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public async Task<string> PostCustAd(MultipartFormDataContent dataContent)
        {
            var token = await SecureStorage.GetAsync("jwt_token");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("User not logged in.");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _httpClient.PostAsync("Farm/insertAd", dataContent);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Upload failed. Please try again later: {response.StatusCode}");
            }
        }

        public async Task<string> UpdateCustAd(MultipartFormDataContent dataContent)
        {
            var token = await SecureStorage.GetAsync("jwt_token");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("User not logged in.");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _httpClient.PutAsync("Farm", dataContent);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Upload failed. Please try again: {response.StatusCode}");
            }
        }


        public async Task<string> DeleteCustAd(int custid)
        {           
            HttpResponseMessage response = await _httpClient.DeleteAsync("Farm/" + custid);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Upload failed. Please try again: {response.StatusCode}");
            }
        }


        public async Task<object> DeleteUserAccount(string userguid)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("Account/deleteaccount/" + userguid);

            try
            {
                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return result;
                }
                else
                {
                    var validation = JsonSerializer.Deserialize<ErrorResponse>(result);

                    if (validation?.errors != null)
                        return validation;

                    else if (validation?.error_msg != null)
                        return new ErrorResponse
                        {
                            error_msg = validation.error_msg,
                        };

                    return new ErrorResponse
                    {
                        error_msg = result.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Unknown Error. Unable to delete Account. {ex.Message}.");
            }
        }
    }
}
