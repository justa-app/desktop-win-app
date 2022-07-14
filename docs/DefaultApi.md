# WindowsApplication.Client.Api.DefaultApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateMessageMessagePost**](DefaultApi.md#createmessagemessagepost) | **POST** /message | Create Message |
| [**CreateSessionSessionPost**](DefaultApi.md#createsessionsessionpost) | **POST** /session | Create Session |
| [**HealthHealthGet**](DefaultApi.md#healthhealthget) | **GET** /health | Health |
| [**ListExpertSessionsExpertExpertIdGet**](DefaultApi.md#listexpertsessionsexpertexpertidget) | **GET** /expert/{expert_id} | List Expert Sessions |
| [**ListExpertSessionsExpertExpertIdSessionsGet**](DefaultApi.md#listexpertsessionsexpertexpertidsessionsget) | **GET** /expert/{expert_id}/sessions | List Expert Sessions |
| [**ListExpertSessionsExpertExpertIdSessionsSessionIdGet**](DefaultApi.md#listexpertsessionsexpertexpertidsessionssessionidget) | **GET** /expert/{expert_id}/sessions/{session_id} | List Expert Sessions |
| [**ListSessionMessagesMessageGet**](DefaultApi.md#listsessionmessagesmessageget) | **GET** /message | List Session Messages |

<a name="createmessagemessagepost"></a>
# **CreateMessageMessagePost**
> Object CreateMessageMessagePost (Message message)

Create Message

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using WindowsApplication.Client.Api;
using WindowsApplication.Client.Client;
using WindowsApplication.Client.Model;

namespace Example
{
    public class CreateMessageMessagePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var message = new Message(); // Message | 

            try
            {
                // Create Message
                Object result = apiInstance.CreateMessageMessagePost(message);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.CreateMessageMessagePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateMessageMessagePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create Message
    ApiResponse<Object> response = apiInstance.CreateMessageMessagePostWithHttpInfo(message);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.CreateMessageMessagePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **message** | [**Message**](Message.md) |  |  |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createsessionsessionpost"></a>
# **CreateSessionSessionPost**
> Object CreateSessionSessionPost (Session session)

Create Session

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using WindowsApplication.Client.Api;
using WindowsApplication.Client.Client;
using WindowsApplication.Client.Model;

namespace Example
{
    public class CreateSessionSessionPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var session = new Session(); // Session | 

            try
            {
                // Create Session
                Object result = apiInstance.CreateSessionSessionPost(session);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.CreateSessionSessionPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateSessionSessionPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create Session
    ApiResponse<Object> response = apiInstance.CreateSessionSessionPostWithHttpInfo(session);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.CreateSessionSessionPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **session** | [**Session**](Session.md) |  |  |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="healthhealthget"></a>
# **HealthHealthGet**
> Object HealthHealthGet ()

Health

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using WindowsApplication.Client.Api;
using WindowsApplication.Client.Client;
using WindowsApplication.Client.Model;

namespace Example
{
    public class HealthHealthGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);

            try
            {
                // Health
                Object result = apiInstance.HealthHealthGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.HealthHealthGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the HealthHealthGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Health
    ApiResponse<Object> response = apiInstance.HealthHealthGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.HealthHealthGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listexpertsessionsexpertexpertidget"></a>
# **ListExpertSessionsExpertExpertIdGet**
> Object ListExpertSessionsExpertExpertIdGet (string expertId, string sessionId = null, int? skip = null, int? limit = null)

List Expert Sessions

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using WindowsApplication.Client.Api;
using WindowsApplication.Client.Client;
using WindowsApplication.Client.Model;

namespace Example
{
    public class ListExpertSessionsExpertExpertIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var expertId = "expertId_example";  // string | 
            var sessionId = "sessionId_example";  // string |  (optional) 
            var skip = 0;  // int? |  (optional)  (default to 0)
            var limit = 10;  // int? |  (optional)  (default to 10)

            try
            {
                // List Expert Sessions
                Object result = apiInstance.ListExpertSessionsExpertExpertIdGet(expertId, sessionId, skip, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.ListExpertSessionsExpertExpertIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListExpertSessionsExpertExpertIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List Expert Sessions
    ApiResponse<Object> response = apiInstance.ListExpertSessionsExpertExpertIdGetWithHttpInfo(expertId, sessionId, skip, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.ListExpertSessionsExpertExpertIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **expertId** | **string** |  |  |
| **sessionId** | **string** |  | [optional]  |
| **skip** | **int?** |  | [optional] [default to 0] |
| **limit** | **int?** |  | [optional] [default to 10] |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listexpertsessionsexpertexpertidsessionsget"></a>
# **ListExpertSessionsExpertExpertIdSessionsGet**
> Object ListExpertSessionsExpertExpertIdSessionsGet (string expertId, string sessionId = null, int? skip = null, int? limit = null)

List Expert Sessions

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using WindowsApplication.Client.Api;
using WindowsApplication.Client.Client;
using WindowsApplication.Client.Model;

namespace Example
{
    public class ListExpertSessionsExpertExpertIdSessionsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var expertId = "expertId_example";  // string | 
            var sessionId = "sessionId_example";  // string |  (optional) 
            var skip = 0;  // int? |  (optional)  (default to 0)
            var limit = 10;  // int? |  (optional)  (default to 10)

            try
            {
                // List Expert Sessions
                Object result = apiInstance.ListExpertSessionsExpertExpertIdSessionsGet(expertId, sessionId, skip, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.ListExpertSessionsExpertExpertIdSessionsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListExpertSessionsExpertExpertIdSessionsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List Expert Sessions
    ApiResponse<Object> response = apiInstance.ListExpertSessionsExpertExpertIdSessionsGetWithHttpInfo(expertId, sessionId, skip, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.ListExpertSessionsExpertExpertIdSessionsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **expertId** | **string** |  |  |
| **sessionId** | **string** |  | [optional]  |
| **skip** | **int?** |  | [optional] [default to 0] |
| **limit** | **int?** |  | [optional] [default to 10] |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listexpertsessionsexpertexpertidsessionssessionidget"></a>
# **ListExpertSessionsExpertExpertIdSessionsSessionIdGet**
> Object ListExpertSessionsExpertExpertIdSessionsSessionIdGet (string expertId, string sessionId, int? skip = null, int? limit = null)

List Expert Sessions

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using WindowsApplication.Client.Api;
using WindowsApplication.Client.Client;
using WindowsApplication.Client.Model;

namespace Example
{
    public class ListExpertSessionsExpertExpertIdSessionsSessionIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var expertId = "expertId_example";  // string | 
            var sessionId = "sessionId_example";  // string | 
            var skip = 0;  // int? |  (optional)  (default to 0)
            var limit = 10;  // int? |  (optional)  (default to 10)

            try
            {
                // List Expert Sessions
                Object result = apiInstance.ListExpertSessionsExpertExpertIdSessionsSessionIdGet(expertId, sessionId, skip, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.ListExpertSessionsExpertExpertIdSessionsSessionIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListExpertSessionsExpertExpertIdSessionsSessionIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List Expert Sessions
    ApiResponse<Object> response = apiInstance.ListExpertSessionsExpertExpertIdSessionsSessionIdGetWithHttpInfo(expertId, sessionId, skip, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.ListExpertSessionsExpertExpertIdSessionsSessionIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **expertId** | **string** |  |  |
| **sessionId** | **string** |  |  |
| **skip** | **int?** |  | [optional] [default to 0] |
| **limit** | **int?** |  | [optional] [default to 10] |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listsessionmessagesmessageget"></a>
# **ListSessionMessagesMessageGet**
> Object ListSessionMessagesMessageGet (string sessionId, int? skip = null, int? limit = null)

List Session Messages

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using WindowsApplication.Client.Api;
using WindowsApplication.Client.Client;
using WindowsApplication.Client.Model;

namespace Example
{
    public class ListSessionMessagesMessageGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var sessionId = "sessionId_example";  // string | 
            var skip = 0;  // int? |  (optional)  (default to 0)
            var limit = 10;  // int? |  (optional)  (default to 10)

            try
            {
                // List Session Messages
                Object result = apiInstance.ListSessionMessagesMessageGet(sessionId, skip, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.ListSessionMessagesMessageGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListSessionMessagesMessageGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List Session Messages
    ApiResponse<Object> response = apiInstance.ListSessionMessagesMessageGetWithHttpInfo(sessionId, skip, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.ListSessionMessagesMessageGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **sessionId** | **string** |  |  |
| **skip** | **int?** |  | [optional] [default to 0] |
| **limit** | **int?** |  | [optional] [default to 10] |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

