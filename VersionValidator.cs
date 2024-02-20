using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Utils.Versions
{
    public class VersionValidator
    {

#if UNITY_ANDROID
        public static async Task<string> GetVersion(string bundleId)
        {
            string url = $"https://play.google.com/store/apps/details?id={bundleId}";
            string latestVersion = "";
            UnityWebRequest www = UnityWebRequest.Get(url);

            await www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                string responseBody = www.downloadHandler.text;
                string pattern = @"Current Version.+?>([\d.-]+)<\/span>";
                Match match = Regex.Match(responseBody, pattern);

                if (match.Success)
                {
                    latestVersion = match.Groups[1].Value.Trim();
                    Debug.Log("Latest Version: " + latestVersion);
                }
                else
                {
                    pattern = @"\[\[\[""([\d-.]+?)""\]\]";
                    match = Regex.Match(responseBody, pattern);

                    if (match.Success)
                    {
                        latestVersion = match.Groups[1].Value.Trim();
                        Debug.Log("Latest Version (New Layout): " + latestVersion);
                    }
                    else
                    {
                        Debug.LogWarning("Version information not found.");
                    }
                }
            }
            return latestVersion;
        }
#elif UNITY_IOS
        public static async Task<string> GetVersion(string bundleId)
        {
            string url = $"https://itunes.apple.com/lookup?bundleId={bundleId}";
            string latestVersion = "";
            UnityWebRequest www = UnityWebRequest.Get(url);

            await www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                string responseBody = www.downloadHandler.text;
                string pattern = "\"version\":\"(\\d+\\.\\d+)\"";
                Match match = Regex.Match(responseBody, pattern);

                if (match.Success)
                {
                    latestVersion = match.Groups[1].Value;
                    Debug.Log("Latest Version: " + latestVersion);
                }
                else
                {
                    Debug.LogWarning("Version information not found.");
                }
            }
            return latestVersion;
        }
#endif
        
    }
}