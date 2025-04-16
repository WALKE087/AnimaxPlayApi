using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace AnimaxPlayApi.Infrastructure.ExternalServices.Firebase
{
    public class FirebaseAuthService
    {
        private readonly FirebaseAuth _auth;
        public FirebaseAuthService()
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    //Credential = GoogleCredential.FromFile("Infrastructure/Firebase/firebase-adminsdk.json")
                });
            }

            _auth = FirebaseAuth.DefaultInstance;
        }

        public async Task<FirebaseToken> VerifyTokenAsync(string idToken)
        {
            return await _auth.VerifyIdTokenAsync(idToken);
        }
    }
}
