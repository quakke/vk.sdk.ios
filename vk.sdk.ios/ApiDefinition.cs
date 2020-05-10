using System;
using System.Threading.Tasks;
using CoreFoundation;
using Foundation;
using ObjCRuntime;
using UIKit;
using VKontakte.API.Methods;
using VKontakte.API.Models;
using VKontakte.Core;
using WebKit;

namespace VKontakte
{
    [Static]
	partial interface VKPermissions
	{
		// extern NSString *const VK_PER_NOTIFY;
		[Field ("VK_PER_NOTIFY", "__Internal")]
		NSString Notify { get; }

		// extern NSString *const VK_PER_NOTES;
		[Field ("VK_PER_NOTES", "__Internal")]
		NSString Notes { get; }

		// extern NSString *const VK_PER_PAGES;
		[Field ("VK_PER_PAGES", "__Internal")]
		NSString Pages { get; }

		// extern NSString *const VK_PER_STATUS;
		[Field ("VK_PER_STATUS", "__Internal")]
		NSString Status { get; }

		// extern NSString *const VK_PER_WALL;
		[Field ("VK_PER_WALL", "__Internal")]
		NSString Wall { get; }

		// extern NSString *const VK_PER_GROUPS;
		[Field ("VK_PER_GROUPS", "__Internal")]
		NSString Groups { get; }

		// extern NSString *const VK_PER_MESSAGES;
		[Field ("VK_PER_MESSAGES", "__Internal")]
		NSString Messages { get; }

		// extern NSString *const VK_PER_NOTIFICATIONS;
		[Field ("VK_PER_NOTIFICATIONS", "__Internal")]
		NSString Notifications { get; }

		// extern NSString *const VK_PER_STATS;
		[Field ("VK_PER_STATS", "__Internal")]
		NSString Stats { get; }

		// extern NSString *const VK_PER_OFFLINE;
		[Field ("VK_PER_OFFLINE", "__Internal")]
		NSString Offline { get; }

		// extern NSString *const VK_PER_NOHTTPS;
		[Field ("VK_PER_NOHTTPS", "__Internal")]
		NSString NoHttps { get; }

		// extern NSString *const VK_PER_EMAIL;
		[Field("VK_PER_EMAIL", "__Internal")]
		NSString Email { get; }
	}
	
	interface IVKSdkDelegate
	{
	}

	// @protocol VKSdkDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface VKSdkDelegate
	{
		// @required -(void)vkSdkAccessAuthorizationFinishedWithResult:(VKAuthorizationResult *)result;
		[Abstract]
		[Export ("vkSdkAccessAuthorizationFinishedWithResult:")]
		void AccessAuthorizationFinished (VKAuthorizationResult result);

		// @required -(void)vkSdkUserAuthorizationFailed;
		[Abstract]
		[Export ("vkSdkUserAuthorizationFailed")]
		void UserAuthorizationFailed ();

		// @optional -(void)vkSdkAuthorizationStateUpdatedWithResult:(VKAuthorizationResult*)result;
		[Export ("vkSdkAuthorizationStateUpdatedWithResult:")]
		void AuthorizationStateUpdated (VKAuthorizationResult result);

		// @optional -(void)vkSdkAccessTokenUpdated:(VKAccessToken *)newToken oldToken:(VKAccessToken *)oldToken;
		[Export ("vkSdkAccessTokenUpdated:oldToken:")]
		void AccessTokenUpdated (VKAccessToken newToken, VKAccessToken oldToken);

		// @optional -(void)vkSdkTokenHasExpired:(VKAccessToken *)expiredToken;
		[Export ("vkSdkTokenHasExpired:")]
		void TokenHasExpired (VKAccessToken expiredToken);
	}

	interface IVKSdkUIDelegate
	{
	}

	// @protocol VKSdkUIDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface VKSdkUIDelegate
	{
		// @required -(void)vkSdkShouldPresentViewController:(UIViewController *)controller;
		[Abstract]
		[Export ("vkSdkShouldPresentViewController:")]
		void ShouldPresentViewController (UIViewController controller);

		// @required -(void)vkSdkNeedCaptchaEnter:(VKError *)captchaError;
		[Abstract]
		[Export ("vkSdkNeedCaptchaEnter:")]
		void NeedCaptchaEnter (VKError captchaError);

		// @optional -(void)vkSdkWillDismissViewController:(UIViewController *)controller;
		[Export ("vkSdkWillDismissViewController:")]
		void WillDismissViewController (UIViewController controller);

		// @optional -(void)vkSdkDidDismissViewController:(UIViewController *)controller;
		[Export ("vkSdkDidDismissViewController:")]
		void DidDismissViewController (UIViewController controller);
	}

	// @interface VKSdk : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface VKSdk
	{
		// @property (readwrite, nonatomic, weak) id<VKSdkUIDelegate> _Nullable uiDelegate;
		[NullAllowed, Export ("uiDelegate", ArgumentSemantic.Weak)]
		IVKSdkUIDelegate UiDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * currentAppId;
		[Export ("currentAppId")]
		string CurrentAppId { get; }

		// @property (readonly, copy, nonatomic) NSString * apiVersion;
		[Export ("apiVersion")]
		string ApiVersion { get; }

		// +(instancetype)instance;
		[Static]
		[Export ("instance")]
		VKSdk Instance { get; }

		// +(BOOL)initialized;
		[Static]
		[Export("initialized")]
		bool Initialized { get; }

		// +(instancetype)initializeWithAppId:(NSString *)appId;
		[Static]
		[Export ("initializeWithAppId:")]
		VKSdk Initialize (string appId);

		// +(instancetype)initializeWithAppId:(NSString *)appId apiVersion:(NSString *)version;
		[Static]
		[Export ("initializeWithAppId:apiVersion:")]
		VKSdk Initialize (string appId, string version);

		// -(void)registerDelegate:(id<VKSdkDelegate>)delegate;
		[Export ("registerDelegate:")]
		void RegisterDelegate (IVKSdkDelegate @delegate);

		// -(void)unregisterDelegate:(id<VKSdkDelegate>)delegate;
		[Export ("unregisterDelegate:")]
		void UnregisterDelegate (IVKSdkDelegate @delegate);

		// +(void)authorize:(NSArray *)permissions;
		[Static]
		[Export ("authorize:")]
		void Authorize (string[] permissions);

		// +(void)authorize:(NSArray *)permissions withOptions:(VKAuthorizationOptions)options;
		[Static]
		[Export ("authorize:withOptions:")]
		void Authorize (string[] permissions, VKAuthorizationOptions options);

		// +(VKAccessToken *)accessToken;
		[Static]
		[Export ("accessToken")]
		VKAccessToken AccessToken { get; }

		// +(BOOL)processOpenURL:(NSURL *)passedUrl fromApplication:(NSString *)sourceApplication;
		[Static]
		[Export ("processOpenURL:fromApplication:")]
		bool ProcessOpenUrl (NSUrl passedUrl, string sourceApplication);

		// +(BOOL)isLoggedIn;
		[Static]
		[Export ("isLoggedIn")]
		bool IsLoggedIn { get; }

		// +(void)wakeUpSession:(NSArray *)permissions completeBlock:(void (^)(VKAuthorizationState, NSError *))wakeUpBlock;
		[Static]
		[Export ("wakeUpSession:completeBlock:")]
		void WakeUpSession (string[] permissions, Action<VKAuthorizationState, NSError> wakeUpBlock);

		// +(void)forceLogout;
		[Static]
		[Export ("forceLogout")]
		void ForceLogout ();

		// +(BOOL)vkAppMayExists;
		[Static]
		[Export ("vkAppMayExists")]
		bool VkAppMayExists { get; }

		// -(BOOL)hasPermissions:(NSArray *)permissions;
		[Export ("hasPermissions:")]
		bool HasPermissions (string[] permissions);

		// +(void)setSchedulerEnabled:(BOOL)enabled;
		[Static]
		[Export ("setSchedulerEnabled:")]
		void SetSchedulerEnabled (bool enabled);
	}
	
	// @interface VKAuthorizationResult : VKObject
	[BaseType (typeof(VKObject))]
	interface VKAuthorizationResult
	{
		// @property (readonly, nonatomic, strong) VKAccessToken * token;
		[Export ("token", ArgumentSemantic.Strong)]
		VKAccessToken Token { get; }

		// @property (readonly, nonatomic, strong) VKUser * user;
		[Export ("user", ArgumentSemantic.Strong)]
		VKUser User { get; }

		// @property (readonly, nonatomic, strong) NSError * error;
		[Export ("error", ArgumentSemantic.Strong)]
		NSError Error { get; }

		// @property (readonly, assign, nonatomic) VKAuthorizationState state;
		[Export ("state", ArgumentSemantic.Assign)]
		VKAuthorizationState State { get; }
	}

	// @interface VKMutableAuthorizationResult : VKAuthorizationResult
	[BaseType (typeof(VKAuthorizationResult))]
	interface VKMutableAuthorizationResult
	{
		// @property (readwrite, nonatomic, strong) VKAccessToken * token;
		[Export ("token", ArgumentSemantic.Strong)]
		VKAccessToken Token { get; set; }

		// @property (readwrite, nonatomic, strong) VKUser * user;
		[Export ("user", ArgumentSemantic.Strong)]
		VKUser User { get; set; }

		// @property (readwrite, nonatomic, strong) NSError * error;
		[Export ("error", ArgumentSemantic.Strong)]
		NSError Error { get; set; }

		// @property (assign, readwrite, nonatomic) VKAuthorizationState state;
		[Export ("state", ArgumentSemantic.Assign)]
		VKAuthorizationState State { get; set; }
	}
	
	// @interface VKAccessToken : VKObject <NSCoding>
	[BaseType (typeof(VKObject))]
	interface VKAccessToken : INSCoding
	{
		// @property (readonly, copy, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, copy, nonatomic) NSString * userId;
		[Export ("userId")]
		string UserId { get; }

		// @property (readonly, copy, nonatomic) NSString * secret;
		[Export ("secret")]
		string Secret { get; }

		// @property (readonly, copy, nonatomic) NSArray * permissions;
		[Export ("permissions", ArgumentSemantic.Copy)]
		string[] Permissions { get; }

		// @property (readonly, copy, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; }

		// @property (readonly, assign, nonatomic) NSInteger expiresIn;
		[Export ("expiresIn")]
		nint ExpiresIn { get; }

		// @property (readonly, assign, nonatomic) BOOL httpsRequired;
		[Export ("httpsRequired")]
		bool HttpsRequired { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval created;
		[Export ("created")]
		double Created { get; }

		// @property (readonly, nonatomic, strong) VKUser * localUser;
		[Export ("localUser", ArgumentSemantic.Strong)]
		VKUser LocalUser { get; }

		// +(instancetype)tokenFromUrlString:(NSString *)urlString;
		[Static]
		[Export ("tokenFromUrlString:")]
		VKAccessToken TokenFromUrlString (string urlString);

		// +(instancetype)tokenWithToken:(NSString *)accessToken secret:(NSString *)secret userId:(NSString *)userId;
		[Static]
		[Export ("tokenWithToken:secret:userId:")]
		VKAccessToken TokenFromToken (string accessToken, string secret, string userId);

		// +(instancetype)savedToken:(NSString *)defaultsKey;
		[Static]
		[Export ("savedToken:")]
		VKAccessToken TokenFromDefaults (string defaultsKey);

		// -(void)saveTokenToDefaults:(NSString *)defaultsKey;
		[Export ("saveTokenToDefaults:")]
		void SaveTokenToDefaults (string defaultsKey);

		// -(BOOL)isExpired;
		[Export ("isExpired")]
		bool IsExpired { get; }

		// +(void)delete:(NSString *)service;
		[Static]
		[Export ("delete:")]
		void Delete (string service);
	}

	// @interface VKAccessTokenMutable : VKAccessToken
	[BaseType (typeof(VKAccessToken))]
	interface VKAccessTokenMutable
	{
		// @property (readwrite, copy, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * userId;
		[Export ("userId")]
		string UserId { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * secret;
		[Export ("secret")]
		string Secret { get; set; }

		// @property (readwrite, copy, nonatomic) NSArray * permissions;
		[Export ("permissions", ArgumentSemantic.Copy)]
		string[] Permissions { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL httpsRequired;
		[Export ("httpsRequired")]
		bool HttpsRequired { get; set; }

		// @property (assign, readwrite, nonatomic) NSInteger expiresIn;
		[Export ("expiresIn")]
		nint ExpiresIn { get; set; }

		// @property (readwrite, nonatomic, strong) VKUser * localUser;
		[Export ("localUser", ArgumentSemantic.Strong)]
		VKUser LocalUser { get; set; }
	}
	
	// @interface VKApiObject : VKObject <VKApiObject>
	[BaseType (typeof(VKObject))]
	interface VKApiObject // TODO : IVKApiObject
	{
		// @property (nonatomic, strong) NSDictionary * fields;
		[Export ("fields", ArgumentSemantic.Strong)]
		NSDictionary Fields { get; set; }

		// -(instancetype)initWithDictionary:(NSDictionary *)dict;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dict);

		// -(NSDictionary *)serialize;
		[Export ("serialize")]
		NSDictionary Serialize ();
		
	}
	
	// @interface VKUser : VKApiObject
	[BaseType (typeof(VKApiObject))]
	interface VKUser
	{
		// @property (nonatomic, strong) NSNumber * id;
		[Export ("id", ArgumentSemantic.Strong)]
		NSNumber id { get; set; }

		// @property (nonatomic, strong) NSString * first_name;
		[Export ("first_name", ArgumentSemantic.Strong)]
		string first_name { get; set; }

		// @property (nonatomic, strong) NSString * last_name;
		[Export ("last_name", ArgumentSemantic.Strong)]
		string last_name { get; set; }

		// @property (nonatomic, strong) NSString * first_name_acc;
		[Export ("first_name_acc", ArgumentSemantic.Strong)]
		string first_name_acc { get; set; }

		// @property (nonatomic, strong) NSString * last_name_acc;
		[Export ("last_name_acc", ArgumentSemantic.Strong)]
		string last_name_acc { get; set; }

		// @property (nonatomic, strong) NSString * first_name_gen;
		[Export ("first_name_gen", ArgumentSemantic.Strong)]
		string first_name_gen { get; set; }

		// @property (nonatomic, strong) NSString * last_name_gen;
		[Export ("last_name_gen", ArgumentSemantic.Strong)]
		string last_name_gen { get; set; }

		// @property (nonatomic, strong) NSString * first_name_dat;
		[Export ("first_name_dat", ArgumentSemantic.Strong)]
		string first_name_dat { get; set; }

		// @property (nonatomic, strong) NSString * last_name_dat;
		[Export ("last_name_dat", ArgumentSemantic.Strong)]
		string last_name_dat { get; set; }

		// @property (nonatomic, strong) NSString * first_name_ins;
		[Export ("first_name_ins", ArgumentSemantic.Strong)]
		string first_name_ins { get; set; }

		// @property (nonatomic, strong) NSString * last_name_ins;
		[Export ("last_name_ins", ArgumentSemantic.Strong)]
		string last_name_ins { get; set; }

		// @property (nonatomic, strong) NSNumber * sex;
		[Export ("sex", ArgumentSemantic.Strong)]
		NSNumber sex { get; set; }

		// @property (nonatomic, strong) NSNumber * invited_by;
		[Export ("invited_by", ArgumentSemantic.Strong)]
		NSNumber invited_by { get; set; }

		// @property (nonatomic, strong) NSString * bdate;
		[Export ("bdate", ArgumentSemantic.Strong)]
		string bdate { get; set; }

		// @property (nonatomic, strong) NSMutableArray * lists;
		[Export ("lists", ArgumentSemantic.Strong)]
		NSMutableArray lists { get; set; }

		// @property (nonatomic, strong) NSString * screen_name;
		[Export ("screen_name", ArgumentSemantic.Strong)]
		string screen_name { get; set; }

		// @property (nonatomic, strong) NSNumber * has_mobile;
		[Export ("has_mobile", ArgumentSemantic.Strong)]
		NSNumber has_mobile { get; set; }

		// @property (nonatomic, strong) NSNumber * rate;
		[Export ("rate", ArgumentSemantic.Strong)]
		NSNumber rate { get; set; }

		// @property (nonatomic, strong) NSString * mobile_phone;
		[Export ("mobile_phone", ArgumentSemantic.Strong)]
		string mobile_phone { get; set; }

		// @property (nonatomic, strong) NSString * home_phone;
		[Export ("home_phone", ArgumentSemantic.Strong)]
		string home_phone { get; set; }

		// @property (assign, nonatomic) BOOL can_post;
		[Export ("can_post")]
		bool can_post { get; set; }

		// @property (assign, nonatomic) BOOL can_see_all_posts;
		[Export ("can_see_all_posts")]
		bool can_see_all_posts { get; set; }

		// @property (nonatomic, strong) NSString * status;
		[Export ("status", ArgumentSemantic.Strong)]
		string status { get; set; }

		// @property (assign, nonatomic) _Bool status_loaded;
		[Export ("status_loaded")]
		bool status_loaded { get; set; }

		// @property (nonatomic, strong) NSString * nickname;
		[Export ("nickname", ArgumentSemantic.Strong)]
		string nickname { get; set; }

		// @property (nonatomic, strong) NSNumber * wall_comments;
		[Export ("wall_comments", ArgumentSemantic.Strong)]
		NSNumber wall_comments { get; set; }

		// @property (assign, nonatomic) BOOL can_write_private_message;
		[Export ("can_write_private_message")]
		bool can_write_private_message { get; set; }

		// @property (nonatomic, strong) NSString * phone;
		[Export ("phone", ArgumentSemantic.Strong)]
		string phone { get; set; }

		// @property (nonatomic, strong) NSString * about;
		[Export ("about", ArgumentSemantic.Strong)]
		string about { get; set; }

		// @property (nonatomic, strong) NSString * quoutes;
		[Export ("quoutes", ArgumentSemantic.Strong)]
		string quoutes { get; set; }

		// @property (nonatomic, strong) NSString * activities;
		[Export ("activities", ArgumentSemantic.Strong)]
		string activities { get; set; }

		// @property (assign, nonatomic) NSTimeInterval bdateIntervalSort;
		[Export ("bdateIntervalSort")]
		double bdateIntervalSort { get; set; }

		// @property (nonatomic, strong) NSNumber * verified;
		[Export ("verified", ArgumentSemantic.Strong)]
		NSNumber verified { get; set; }

		// @property (nonatomic, strong) NSString * deactivated;
		[Export ("deactivated", ArgumentSemantic.Strong)]
		string deactivated { get; set; }

		// @property (nonatomic, strong) NSString * site;
		[Export ("site", ArgumentSemantic.Strong)]
		string site { get; set; }

		// @property (nonatomic, strong) NSString * home_town;
		[Export ("home_town", ArgumentSemantic.Strong)]
		string home_town { get; set; }

		// @property (nonatomic, strong) NSNumber * blacklisted;
		[Export ("blacklisted", ArgumentSemantic.Strong)]
		NSNumber blacklisted { get; set; }

		// @property (nonatomic, strong) NSNumber * blacklisted_by_me;
		[Export ("blacklisted_by_me", ArgumentSemantic.Strong)]
		NSNumber blacklisted_by_me { get; set; }

		// @property (nonatomic, strong) NSString * contact;
		[Export ("contact", ArgumentSemantic.Strong)]
		string contact { get; set; }

		// @property (nonatomic, strong) NSNumber * request_sent;
		[Export ("request_sent", ArgumentSemantic.Strong)]
		NSNumber request_sent { get; set; }

		// @property (nonatomic, strong) NSNumber * common_count;
		[Export ("common_count", ArgumentSemantic.Strong)]
		NSNumber common_count { get; set; }

		// @property (nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Strong)]
		string name { get; set; }

		// @property (nonatomic, strong) NSString * name_gen;
		[Export ("name_gen", ArgumentSemantic.Strong)]
		string name_gen { get; set; }
	}
	
	// @interface VKUsersArray : VKApiObjectArray
	[BaseType (typeof(VKApiObjectArray))]
	interface VKUsersArray
	{
	}
}

namespace VKontakte.Views
{
    // @interface VKAuthorizationContext : VKObject
    [BaseType (typeof(VKObject))]
	interface VKAuthorizationContext
	{
		// @property (readonly, nonatomic, strong) NSString * clientId;
		[Export("clientId", ArgumentSemantic.Strong)]
		string ClientId { get; }

		// @property (readonly, nonatomic, strong) NSString * displayType;
		[Export("displayType", ArgumentSemantic.Strong)]
		string DisplayType { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * scope;
		[Export("scope", ArgumentSemantic.Strong)]
		string[] Scope { get; }

		// @property (readonly, nonatomic) BOOL revoke;
		[Export("revoke")]
		bool Revoke { get; }

		// +(instancetype)contextWithAuthType:(VKAuthorizationType)authType clientId:(NSString *)clientId displayType:(NSString *)displayType scope:(NSArray<NSString *> *)scope revoke:(BOOL)revoke;
		[Static]
		[Export("contextWithAuthType:clientId:displayType:scope:revoke:")]
		VKAuthorizationContext Create (VKAuthorizationType authType, string clientId, string displayType, string[] scope, bool revoke);
	}

	// @interface VKAuthorizeController : UIViewController <IWKUIDelegate>
	[BaseType (typeof(UIViewController))]
	interface VKAuthorizeController : IWKUIDelegate
	{
		// +(void)presentForAuthorizeWithAppId:(NSString *)appId andPermissions:(NSArray *)permissions revokeAccess:(BOOL)revoke displayType:(VKDisplayType)displayType;
		[Static]
		[Export ("presentForAuthorizeWithAppId:andPermissions:revokeAccess:displayType:")]
		void PresentForAuthorize (string appId, string[] permissions, bool revoke, string displayType);

		// +(void)presentForValidation:(VKError *)validationError;
		[Static]
		[Export ("presentForValidation:")]
		void PresentForValidation (VKError validationError);

		// +(NSURL *)buildAuthorizationURLWithContext:(VKAuthorizationContext *)ctx;
		[Static]
		[Export("buildAuthorizationURLWithContext:")]
		NSUrl BuildAuthorizationUrl (VKAuthorizationContext ctx);
	}
	
	// @interface VKCaptchaViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface VKCaptchaViewController
	{
		// +(instancetype)captchaControllerWithError:(VKError *)error;
		[Static]
		[Export ("captchaControllerWithError:")]
		VKCaptchaViewController Create (VKError error);

		// -(void)presentIn:(UIViewController *)viewController;
		[Export ("presentIn:")]
		void PresentIn (UIViewController viewController);
	}
}

namespace VKontakte.Core
{
    // @interface VKObject : NSObject
    [BaseType (typeof(NSObject))]
	interface VKObject
	{
	}
	
	// @interface VKError : VKObject
	[BaseType(typeof(VKObject))]
	interface VKError
	{
		/// Contains system HTTP error
		// @property(nonatomic, strong) NSError *httpError;
		[Export ("httpError", ArgumentSemantic.Strong)]
		NSError HttpError { get; set; }
		
		/// Describes API error
		// @property(nonatomic, strong) VKError *apiError;
		[Export ("apiError", ArgumentSemantic.Strong)]
		VKError ApiError { get; set; }
		
		/// Request which caused error
		// @property(nonatomic, strong) VKRequest *request;
		[Export ("request", ArgumentSemantic.Strong)]
		VKRequest Request { get; set; }
		
		/// May contains such errors:\n <b>HTTP status code</b> if HTTP error occured;\n <b>VK_API_ERROR</b> if API error occured;\n <b>VK_API_CANCELED</b> if request was canceled;\n <b>VK_API_REQUEST_NOT_PREPARED</b> if error occured while preparing request;
		// @property(nonatomic, assign) NSInteger errorCode;
		[Export ("errorCode", ArgumentSemantic.Assign)]
		NSNumber ErrorCode { get; set; }
		
		/// API error message
		// @property(nonatomic, strong) NSString *errorMessage;
		[Export ("errorMessage", ArgumentSemantic.Strong)]
		NSString ErrorMessage { get; set; }
		
		/// Reason for authorization fail
		// @property(nonatomic, strong) NSString *errorReason;
		[Export ("errorReason", ArgumentSemantic.Strong)]
		NSString ErrorReason { get; set; }
		
		// Localized error text from server if there is one
		// @property(nonatomic, strong) NSString *errorText;
		[Export ("errorText", ArgumentSemantic.Strong)]
		NSString ErrorText { get; set; }
		
		/// API parameters passed to request
		// @property(nonatomic, strong) NSDictionary *requestParams;
		[Export ("requestParams", ArgumentSemantic.Strong)]
		NSDictionary RequestParams { get; set; }
		
		/// Captcha identifier for captcha-check
		// @property(nonatomic, strong) NSString *captchaSid;
		[Export ("captchaSid", ArgumentSemantic.Strong)]
		NSString CaptchaSid { get; set; }
		
		/// Image for captcha-check
		// @property(nonatomic, strong) NSString *captchaImg;
		[Export ("captchaImg", ArgumentSemantic.Strong)]
		NSString CaptchaImg { get; set; }
		
		/// Redirection address if validation check required
		// @property(nonatomic, strong) NSString *redirectUri;
		[Export ("redirectUri", ArgumentSemantic.Strong)]
		NSString RedirectUri { get; set; }
		
		// @property(nonatomic, strong) id json;
		[Export ("json", ArgumentSemantic.Strong)]
		NSObject Json { get; set; }
	}
	
	// @interface VKRequestTiming : VKObject
	[BaseType(typeof(VKObject))]
	interface VKRequestTiming
	{
		/// Date of request start
		// @property(nonatomic, strong) NSDate *startTime;
		[Export("startTime", ArgumentSemantic.Strong)]
		NSDate StartTime { get; set; }
		
		/// Date of request finished (after all operations)
		// @property(nonatomic, strong) NSDate *finishTime;
		[Export("finishTime", ArgumentSemantic.Strong)]
		NSDate FinishTime { get; set; }

		/// Interval of networking load time
		// @property(nonatomic, assign) NSTimeInterval loadTime;
		[Export("loadTime", ArgumentSemantic.Strong)]
		double LoadTime { get; set; }

		/// Interval of model parsing time
		// @property(nonatomic, assign) NSTimeInterval parseTime;
		[Export("parseTime", ArgumentSemantic.Assign)]
		double ParseTime { get; set; }
		
		/// Total time, as difference (finishTime - startTime)
		// @property(nonatomic, readonly) NSTimeInterval totalTime;
		[Export("totalTime")]
		double TotalTime { get; }
	}

	// @interface VKRequest : VKObject
	[BaseType(typeof(VKObject))]
	interface VKRequest
	{
		/// Specify progress for uploading or downloading. Useless for text requests (because gzip encoding bytesTotal will always return -1)
		// @property(nonatomic, copy) void (^progressBlock)(VKProgressType progressType, long long bytesLoaded, long long bytesTotal);
		// TODO: хз как это сделать 
		
		/// Specify completion block for request
		// @property(nonatomic, copy) void (^completeBlock)(VKResponse *response);
		[Export ("completeBlock", ArgumentSemantic.Copy)]
		Action<VKResponse> CompleteBlock { get; set; }
		
		/// Specity error (HTTP or API) block for request.
		// @property(nonatomic, copy) void (^errorBlock)(NSError *error);
		[Export ("errorBlock", ArgumentSemantic.Copy)]
		Action<NSError> ErrorBlock { get; set; }

		/// Specify attempts for request loading if caused HTTP-error. 0 for infinite
		// @property(nonatomic, assign) int attempts;
		[Export("attempts", ArgumentSemantic.Assign)]
		NSNumber Attempts { get; set; }
		
		/// Use HTTPS requests (by default is YES). If http-request is impossible (user denied no https access), SDK will load https version
		// @property(nonatomic, assign) BOOL secure;
		[Export("secure", ArgumentSemantic.Assign)]
		bool Secure { get; set; }
		
		/// Sets current system language as default for API data
		// @property(nonatomic, assign) BOOL useSystemLanguage;
		[Export("useSystemLanguage", ArgumentSemantic.Assign)]
		bool UseSystemLanguage { get; set; }
		
		/// Set to NO if you don't need automatic model parsing
		// @property(nonatomic, assign) BOOL parseModel;
		[Export("parseModel", ArgumentSemantic.Assign)]
		bool ParseModel { get; set; }
		
		/// Set to YES if you need info about request timing
		// @property(nonatomic, assign) BOOL debugTiming;
		[Export("debugTiming", ArgumentSemantic.Assign)]
		bool DebugTiming { get; set; }
		
		/// Timeout for this request
		// @property(nonatomic, assign) NSInteger requestTimeout;
		[Export("requestTimeout", ArgumentSemantic.Assign)]
		NSNumber RequestTimeout { get; set; }
		
		/// Sets dispatch queue for returning result
		// @property(nonatomic, assign) dispatch_queue_t responseQueue;
		[Export ("responseQueue", ArgumentSemantic.Assign)]
		DispatchQueue ResponseQueue { get; set; }

		/// Set to YES if you need to freeze current thread for response
		// @property(nonatomic, assign) BOOL waitUntilDone;
		[Export("waitUntilDone", ArgumentSemantic.Assign)]
		bool WaitUntilDone { get; set; }
		
		/// Returns method for current request, e.g. users.get
		// @property(nonatomic, readonly) NSString *methodName;
		[Export("methodName")]
		NSString MethodName { get; }
		
		/// Returns HTTP-method for current request
		// @property(nonatomic, readonly) NSString *httpMethod;
		[Export("httpMethod")]
		NSString HttpMethod { get; }
		
		/// Returns list of method parameters (without common parameters)
		// @property(nonatomic, readonly) NSDictionary *methodParameters;
		[Export("methodParameters")]
		NSDictionary MethodParameters { get; }
		
		/// Returns http operation that can be enqueued
		// @property(nonatomic, readonly) NSOperation *executionOperation;
		[Export("executionOperation")]
		NSOperation ExecutionOperation { get; }
		
		/// Returns info about request timings
		// @property(nonatomic, readonly) VKRequestTiming *requestTiming;
		[Export("requestTiming")]
		VKRequestTiming RequestTiming { get; }
		
		/// Return YES if current request was started
		// @property(nonatomic, readonly) BOOL isExecuting;
		[Export("isExecuting")]
		bool IsExecuting { get; }
		
		/// Return YES if current request was started
		// @property(nonatomic, copy) NSArray *preventThisErrorsHandling;
		[Export ("preventThisErrorsHandling", ArgumentSemantic.Copy)]
		NSNumber[] PreventThisErrorsHandling { get; set; }
		
		// +(instancetype)requestWithMethod:(NSString *)method andParameters:(NSDictionary *)parameters andHttpMethod:(NSString *)httpMethod __attribute__((deprecated("")));
		[Obsolete]
		[Static]
		[Export ("requestWithMethod:andParameters:andHttpMethod:")]
		VKRequest Create (string method, [NullAllowed] NSDictionary parameters, string httpMethod);

		// +(instancetype)requestWithMethod:(NSString *)method andParameters:(NSDictionary *)parameters __attribute__((deprecated("")));
		[Obsolete]
		[Static]
		[Export ("requestWithMethod:andParameters:")]
		VKRequest Create (string method, [NullAllowed] NSDictionary parameters);

		// +(instancetype)requestWithMethod:(NSString *)method andParameters:(NSDictionary *)parameters modelClass:(Class)modelClass __attribute__((deprecated("")));
		[Obsolete]
		[Static]
		[Export ("requestWithMethod:andParameters:modelClass:")]
		VKRequest Create (string method, [NullAllowed] NSDictionary parameters, Class modelClass);

		// +(instancetype)requestWithMethod:(NSString *)method andParameters:(NSDictionary *)parameters andHttpMethod:(NSString *)httpMethod classOfModel:(Class)modelClass __attribute__((deprecated("")));
		[Obsolete]
		[Static]
		[Export ("requestWithMethod:andParameters:andHttpMethod:classOfModel:")]
		VKRequest Create (string method, [NullAllowed] NSDictionary parameters, string httpMethod, Class modelClass);

		// -(NSURLRequest *)getPreparedRequest;
		[Export ("getPreparedRequest")]
		NSUrlRequest PreparedRequest { get; }

		// -(void)executeWithResultBlock:(void (^)(VKResponse *))completeBlock errorBlock:(void (^)(NSError *))errorBlock;
		[Export ("executeWithResultBlock:errorBlock:")]
		void Execute (Action<VKResponse> completeBlock, Action<NSError> errorBlock);

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(NSOperation *)createExecutionOperation;
		[Export ("createExecutionOperation")]
		NSOperation CreateExecutionOperation ();

		// -(void)repeat;
		[Export ("repeat")]
		void Repeat ();

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// -(void)addExtraParameters:(NSDictionary *)extraParameters;
		[Export ("addExtraParameters:")]
		void AddExtraParameters (NSDictionary extraParameters);

		// -(void)setPreferredLang:(NSString *)lang;
		[Export ("setPreferredLang:")]
		void SetPreferredLang (string lang);
	}

	// @interface VKResponse : VKObject
	[BaseType (typeof(VKObject))]
	interface VKResponse
	{
		// @property (nonatomic, weak) VKRequest * _Nullable request;
		[NullAllowed, Export ("request", ArgumentSemantic.Weak)]
		VKRequest Request { get; set; }

		// @property (nonatomic, strong) id json;
		[Export ("json", ArgumentSemantic.Strong)]
		NSObject Json { get; set; }

		// @property (nonatomic, strong) id parsedModel;
		[Export ("parsedModel", ArgumentSemantic.Strong)]
		NSObject ParsedModel { get; set; }

		// @property (copy, nonatomic) NSString * responseString;
		[Export ("responseString")]
		string ResponseString { get; set; }
	}
}

namespace VKontakte.API
{
    // @interface VKApi : NSObject
    [BaseType (typeof(NSObject))]
	interface VKApi
	{
		// +(VKApiUsers *)users;
		[Static]
		[Export ("users")]
		VKApiUsers Users { get; }

		// +(VKApiWall *)wall;
		[Static]
		[Export ("wall")]
		VKApiWall Wall { get; }

		// +(VKApiFriends *)friends;
		[Static]
		[Export ("friends")]
		VKApiFriends Friends { get; }

		// +(VKApiGroups *)groups;
		[Static]
		[Export ("groups")]
		VKApiGroups Groups { get; }

		// +(VKRequest *)requestWithMethod:(NSString *)method andParameters:(NSDictionary *)parameters;
		[Static]
		[Export ("requestWithMethod:andParameters:")]
		VKRequest Request (string method, NSDictionary parameters);
	}

	// @interface VKApiFriends : VKApiBase
	[BaseType (typeof(VKApiBase))]
	interface VKApiFriends
	{
		// -(VKRequest *)get;
		[Export ("get")]
		VKRequest Get ();

		// -(VKRequest *)get:(NSDictionary *)params;
		[Export ("get:")]
		VKRequest Get (NSDictionary @params);
	}

	// @interface VKApiPhotos : VKApiBase
	[BaseType (typeof(VKApiBase))]
	interface VKApiPhotos
	{
		// -(VKRequest *)getUploadServer:(NSInteger)albumId;
		[Export ("getUploadServer:")]
		VKRequest GetUploadServer (nint albumId);

		// -(VKRequest *)getUploadServer:(NSInteger)albumId andGroupId:(NSInteger)groupId;
		[Export ("getUploadServer:andGroupId:")]
		VKRequest GetUploadServer (nint albumId, nint groupId);

		// -(VKRequest *)getWallUploadServer;
		[Export ("getWallUploadServer")]
		VKRequest GetWallUploadServer ();

		// -(VKRequest *)getWallUploadServer:(NSInteger)groupId;
		[Export ("getWallUploadServer:")]
		VKRequest GetWallUploadServer (nint groupId);

		// -(VKRequest *)save:(NSDictionary *)params;
		[Export ("save:")]
		VKRequest Save (NSDictionary @params);

		// -(VKRequest *)saveWallPhoto:(NSDictionary *)params;
		[Export ("saveWallPhoto:")]
		VKRequest SaveWallPhoto (NSDictionary @params);
	}

	// @interface VKApiWall : VKApiBase
	[BaseType (typeof(VKApiBase))]
	interface VKApiWall
	{
		// -(VKRequest *)post:(NSDictionary *)params;
		[Export ("post:")]
		VKRequest Post (NSDictionary @params);
	}

	// @interface VKApiGroups : VKApiBase
	[BaseType (typeof(VKApiBase))]
	interface VKApiGroups
	{
		// -(VKRequest *)getById:(NSDictionary *)params;
		[Export ("getById:")]
		VKRequest GetById (NSDictionary @params);
	}
}

namespace VKontakte.API.Models
{
    // @interface VKApiObjectArray : VKApiObject <NSFastEnumeration>
    [BaseType (typeof(VKApiObject))]
	interface VKApiObjectArray // TODO : INSFastEnumeration
	{
		// @property (readonly, nonatomic) NSUInteger count;
		[Export ("count")]
		nuint Count { get; }

		// @property (nonatomic, strong) NSMutableArray * items;
		[Export ("items", ArgumentSemantic.Strong)]
		NSMutableArray Items { get; set; }

		// -(instancetype)initWithDictionary:(NSDictionary *)dict objectClass:(Class)objectClass;
		[Export ("initWithDictionary:objectClass:")]
		IntPtr Constructor (NSDictionary dict, Class objectClass);

		// -(instancetype)initWithArray:(NSArray *)array objectClass:(Class)objectClass;
		[Export ("initWithArray:objectClass:")]
		IntPtr Constructor (VKApiObject[] array, Class objectClass);

		// -(instancetype)initWithArray:(NSArray *)array;
		[Export ("initWithArray:")]
		IntPtr Constructor (VKApiObject[] array);

		// -(id)objectAtIndex:(NSInteger)idx;
		[Export ("objectAtIndex:")]
		VKApiObject ObjectAtIndex (nint idx);

		// -(id)objectAtIndexedSubscript:(NSUInteger)idx __attribute__((availability(ios, introduced=6_0)));
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("objectAtIndexedSubscript:")]
		VKApiObject ObjectAtIndexedSubscript (nuint idx);

		// -(NSEnumerator *)objectEnumerator;
		[Export ("objectEnumerator")]
		NSEnumerator GetObjectEnumerator ();

		// -(NSEnumerator *)reverseObjectEnumerator;
		[Export ("reverseObjectEnumerator")]
		NSEnumerator GetReverseObjectEnumerator ();

		// -(void)addObject:(id)object;
		[Export ("addObject:")]
		void AddObject (VKApiObject @object);

		// -(void)removeObject:(id)object;
		[Export ("removeObject:")]
		void RemoveObject (VKApiObject @object);

		// -(void)insertObject:(id)object atIndex:(NSUInteger)index;
		[Export ("insertObject:atIndex:")]
		void InsertObject (VKApiObject @object, nuint index);

		// -(id)firstObject;
		[Export ("firstObject")]
		VKApiObject FirstObject { get; }

		// -(id)lastObject;
		[Export ("lastObject")]
		VKApiObject LastObject { get; }

		// -(void)serializeTo:(NSMutableDictionary *)dict withName:(NSString *)name;
		[Export ("serializeTo:withName:")]
		void SerializeTo (NSMutableDictionary dict, string name);

		// -(Class)objectClass;
		[Export ("objectClass")]
		Class ObjectClass { get; }
	}
}

namespace VKontakte.API.Methods
{
    [Static]
	partial interface VKApiConst
	{
		// extern NSString *const VK_API_GROUP_ID;
		[Field("VK_API_GROUP_ID", "__Internal")]
		NSString GroupId { get; }

		// extern const VKDisplayType VK_DISPLAY_IOS;
		[Field("VK_DISPLAY_IOS", "__Internal")]
		NSString DisplayiOS { get; }

		// extern const VKDisplayType VK_DISPLAY_MOBILE;
		[Field("VK_DISPLAY_MOBILE", "__Internal")]
		NSString DisplayMobile { get; }

		// Commons
		// extern NSString *const VK_ORIGINAL_CLIENT_BUNDLE;
		[Field("VK_ORIGINAL_CLIENT_BUNDLE", "__Internal")]
		NSString OriginalClientBundle { get; }

		// extern NSString *const VK_ORIGINAL_HD_CLIENT_BUNDLE;
		[Field("VK_ORIGINAL_HD_CLIENT_BUNDLE", "__Internal")]
		NSString OriginalHdClientBundle { get; }

		// extern NSString *const VK_DEBUG_CLIENT_BUNDLE;
		[Field("VK_DEBUG_CLIENT_BUNDLE", "__Internal")]
		NSString DebugClientBundle { get; }

		// extern NSString *const VK_API_USER_ID;
		[Field("VK_API_USER_ID", "__Internal")]
		NSString UserId { get; }

		// extern NSString *const VK_API_USER_IDS;
		[Field("VK_API_USER_IDS", "__Internal")]
		NSString UserIds { get; }

		// extern NSString *const VK_API_FIELDS;
		[Field("VK_API_FIELDS", "__Internal")]
        NSString Fields { get; }

		// extern NSString *const VK_API_SORT;
		[Field("VK_API_SORT", "__Internal")]
        NSString Sort { get; }

		// extern NSString *const VK_API_OFFSET;
		[Field("VK_API_OFFSET", "__Internal")]
        NSString Offset { get; }

		// extern NSString *const VK_API_COUNT;
		[Field("VK_API_COUNT", "__Internal")]
        NSString Count { get; }

		// extern NSString *const VK_API_OWNER_ID;
		[Field("VK_API_OWNER_ID", "__Internal")]
		NSString OwnerId { get; }

		// Auth
		// extern NSString *const VK_API_LANG;
		[Field("VK_API_LANG", "__Internal")]
        NSString Lang { get; }

		// extern NSString *const VK_API_ACCESS_TOKEN;
		[Field("VK_API_ACCESS_TOKEN", "__Internal")]
		NSString AccessToken { get; }
		
		// Get users
		// extern NSString *const VK_API_NAME_CASE;
		[Field("VK_API_NAME_CASE", "__Internal")]
		NSString NameCase { get; }

		// Search
		// extern NSString *const VK_API_Q;
		[Field("VK_API_Q", "__Internal")]
        NSString Q { get; }

		// extern NSString *const VK_API_SEX;
		[Field("VK_API_SEX", "__Internal")]
        NSString Sex { get; }

		// extern NSString *const VK_API_AGE_FROM;
		[Field("VK_API_AGE_FROM", "__Internal")]
		NSString AgeFrom { get; }

		// extern NSString *const VK_API_AGE_TO;
		[Field("VK_API_AGE_TO", "__Internal")]
        NSString AgeTo { get; }

		// extern NSString *const VK_API_BIRTH_DAY;
		[Field("VK_API_BIRTH_DAY", "__Internal")]
		NSString BirthDay { get; }

		// extern NSString *const VK_API_BIRTH_MONTH;
		[Field("VK_API_BIRTH_MONTH", "__Internal")]
		NSString BirthMonth { get; }

		// extern NSString *const VK_API_BIRTH_YEAR;
		[Field("VK_API_BIRTH_YEAR", "__Internal")]
		NSString BirthYear { get; }

		// extern NSString *const VK_API_POSITION;
		[Field("VK_API_POSITION", "__Internal")]
		NSString Position { get; }

		// extern NSString *const VK_API_FRIENDS_ONLY;
		[Field("VK_API_FRIENDS_ONLY", "__Internal")]
		NSString FriendsOnly { get; }

		// extern NSString *const VK_API_MESSAGE;
		[Field("VK_API_MESSAGE", "__Internal")]
		NSString Message { get; }

		// extern NSString *const VK_API_ATTACHMENT;
		[Field("VK_API_ATTACHMENT", "__Internal")]
		NSString Attachment { get; }

		// extern NSString *const VK_API_ATTACHMENTS;
		[Field("VK_API_ATTACHMENTS", "__Internal")]
		NSString Attachments { get; }

		// extern NSString *const VK_API_SERVICES;
		[Field("VK_API_SERVICES", "__Internal")]
		NSString Services { get; }

		// extern NSString *const VK_API_PUBLISH_DATE;
		[Field("VK_API_PUBLISH_DATE", "__Internal")]
		NSString PublishDate { get; }

		// extern NSString *const VK_API_LAT;
		[Field("VK_API_LAT", "__Internal")]
        NSString Lat { get; }

		// extern NSString *const VK_API_LONG;
		[Field("VK_API_LONG", "__Internal")]
        NSString Long { get; }

		// extern NSString *const VK_API_PLACE_ID;
		[Field("VK_API_PLACE_ID", "__Internal")]
		NSString PlaceId { get; }

		// extern NSString *const VK_API_POST_ID;
		[Field("VK_API_POST_ID", "__Internal")]
		NSString PostId { get; }

		// Errors
		// extern NSString *const VK_API_ERROR_CODE;
		[Field("VK_API_ERROR_CODE", "__Internal")]
		NSString ErrorCode { get; }

		// extern NSString *const VK_API_ERROR_MSG;
		[Field("VK_API_ERROR_MSG", "__Internal")]
		NSString ErrorMsg { get; }

		// extern NSString *const VK_API_ERROR_TEXT;
		[Field("VK_API_ERROR_TEXT", "__Internal")]
		NSString ErrorText { get; }

		// extern NSString *const VK_API_REQUEST_PARAMS;
		[Field("VK_API_REQUEST_PARAMS", "__Internal")]
		NSString RequestParams { get; }

		// Captcha
		// extern NSString *const VK_API_CAPTCHA_IMG;
		[Field("VK_API_CAPTCHA_IMG", "__Internal")]
		NSString CaptchaImg { get; }

		// extern NSString *const VK_API_CAPTCHA_SID;
		[Field("VK_API_CAPTCHA_SID", "__Internal")]
		NSString CaptchaSid { get; }

		// extern NSString *const VK_API_CAPTCHA_KEY;
		[Field("VK_API_CAPTCHA_KEY", "__Internal")]
		NSString CaptchaKey { get; }

		// extern NSString *const VK_API_REDIRECT_URI;
		[Field("VK_API_REDIRECT_URI", "__Internal")]
		NSString RedirectUri { get; }
	}
	
	// @interface VKApiBase : VKObject
	[BaseType (typeof(VKObject))]
	interface VKApiBase
	{
		// -(NSString *)getMethodGroup;
		[Export ("getMethodGroup")]
		string MethodGroup { get; }

		// -(VKRequest *)prepareRequestWithMethodName:(NSString *)methodName andParameters:(NSDictionary *)methodParameters;
		[Export ("prepareRequestWithMethodName:parameters:")]
		VKRequest PrepareRequest (string methodName, NSDictionary methodParameters);

		// -(VKRequest *)prepareRequestWithMethodName:(NSString *)methodName andParameters:(NSDictionary *)methodParameters andClassOfModel:(Class)modelClass;
		[Export ("prepareRequestWithMethodName:parameters:modelClass:")]
		VKRequest PrepareRequest (string methodName, NSDictionary methodParameters, Class modelClass);
	}
	
	// @interface VKApiUsers : VKApiBase
	[BaseType (typeof(VKApiBase))]
	interface VKApiUsers
	{
		// -(VKRequest *)get;
		[Export ("get")]
		VKRequest Get ();

		// -(VKRequest *)get:(NSDictionary *)params;
		[Export ("get:")]
		VKRequest Get (NSDictionary @params);

		// -(VKRequest *)search:(NSDictionary *)params;
		[Export ("search:")]
		VKRequest Search (NSDictionary @params);

		// -(VKRequest *)isAppUser;
		[Export ("isAppUser")]
		VKRequest IsAppUser ();

		// -(VKRequest *)isAppUser:(NSInteger)userID;
		[Export ("isAppUser:")]
		VKRequest IsAppUser (nint userId);

		// -(VKRequest *)getSubscriptions;
		[Export ("getSubscriptions")]
		VKRequest GetSubscriptions ();

		// -(VKRequest *)getSubscriptions:(NSDictionary *)params;
		[Export ("getSubscriptions:")]
		VKRequest GetSubscriptions (NSDictionary @params);

		// -(VKRequest *)getFollowers;
		[Export ("getFollowers")]
		VKRequest GetFollowers ();

		// -(VKRequest *)getFollowers:(NSDictionary *)params;
		[Export ("getFollowers:")]
		VKRequest GetFollowers (NSDictionary @params);
	}
}



