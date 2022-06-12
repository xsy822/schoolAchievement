using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CustomAlertBoxDemo
{
    class Modules
    {
        /// <summary>
        /// 向服务器发送post请求，获取json数据
        /// </summary>
        /// <param name="url">服务器url</param>
        /// <param name="postData">一个json字符串</param>
        /// <returns>JObject对象，包含返回数据</returns>
        public static JObject PostUrl(string url, string postData)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.Timeout = 5000;//设置请求超时时间，单位为毫秒
            req.ContentType = "application/json";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return Json2Data(UnescapeUnicode(result));
        }
        /// <summary>
        /// 向服务器发送一个GET请求，获取json数据
        /// </summary>
        /// <param name="url">服务器url</param>
        /// <param name="data">键值对，请求的负载</param>
        /// <returns>JObject对象，包含返回数据</returns>
        public static JObject GetUrl(string url, Dictionary<string, string> data)
        {
            url += "?";
            foreach (KeyValuePair<string, string> vpair in data)
            {
                url += vpair.Key + "=" + vpair.Value + "&";
            }
            Console.WriteLine(url);
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.Timeout = 5000;
            req.ContentType = "application/json";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return Json2Data(UnescapeUnicode(result));
        }
        /// <summary>
        /// 从服务器下载文件到指定路径
        /// </summary>
        /// <param name="url">下载地址</param>
        /// <param name="data">请求承载数据</param>
        /// <param name="filename">保存的文件名</param>
        /// <param name="path">保存路径</param>
        public static void GetFileFromUrl(string url, Dictionary<string, string> data, string filename, string path)
        {
            url += "?";
            foreach (KeyValuePair<string, string> vpair in data)
            {
                url += vpair.Key + "=" + vpair.Value + "&";
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.Timeout = 5000;
            req.ContentType = "application/json";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //重复文件重命名
            path = path + "\\" + filename;
            while (File.Exists(path))
            {
                int index = path.LastIndexOf(".");
                string A = path.Substring(0, index);
                string B = path.Substring(index, (path.Length - index));
                path = A + "[1]" + B;
            }
            FileStream fileStream = new FileStream(path, FileMode.Create);
            long totalBytes = resp.ContentLength;

            byte[] bArr = new byte[1024];
            int size = stream.Read(bArr, 0, (int)bArr.Length);
            long totalDownloadBytes = 0;
            while (size > 0)
            {
                totalDownloadBytes += size;
                fileStream.Write(bArr, 0, size);
                size = stream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            fileStream.Close();
        }
        /// <summary>
        /// 将unicode转义序列(\uxxxx)解码为字符串
        /// </summary>
        /// <param name="str">欲转义的字符串</param>
        /// <returns>转义后的字符串</returns>
        public static string UnescapeUnicode(string str)
        {
            return System.Text.RegularExpressions.Regex.Unescape(str);
        }
        /// <summary>
        /// 将json字符串转换为JObject对象
        /// </summary>
        /// <param name="res">json字符串</param>
        /// <returns>JObject对象</returns>
        public static JObject Json2Data(string res)
        {
            return JsonConvert.DeserializeObject<JObject>(res);
        }
        /// <summary>
        /// 向指定路径文件覆盖写入内容
        /// </summary>
        /// <param name="path">指定文件路径</param>
        /// <param name="content">欲写入的内容</param>
        public static void WriteTo(string path, string content)
        {
            StreamWriter streamWriter = new StreamWriter(path, false);
            streamWriter.Write(content);
            streamWriter.Dispose();
        }
        /// <summary>
        /// 从一个文件读取内容
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>读取到的内容的字符串</returns>
        public static string ReadFrom(string path)
        {
            string res = "";
            if (File.Exists(path))
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);
                res = streamReader.ReadToEnd();
                streamReader.Dispose();
                fileStream.Dispose();
            }
            return res;
        }
        public static JObject PostFileToURL(string path, string token, string url)
        {
            //"https://cloud.xiaoshiyan.top:8081/upload"
            string filename = Path.GetFileName(path);
            int length = File.ReadAllBytes(path).Length;
            var formDatas = new List<FormItemModel>();
            //添加文件
            formDatas.Add(new FormItemModel()
            {
                Key = "file",
                Value = "",
                FileName = filename,
                FileContent = File.OpenRead(path)
            });
            //添加文本
            formDatas.Add(new FormItemModel()
            {
                Key = "length",
                Value = length.ToString()
            });
            formDatas.Add(new FormItemModel()
            {
                Key = "token",
                Value = token
            });
            //提交表单
            return Json2Data(UnescapeUnicode(PostForm(url, formDatas)));

        }
        public static string PostForm(string url, List<FormItemModel> formItems, CookieContainer cookieContainer = null, string refererUrl = null, Encoding encoding = null, int timeOut = 20000)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            #region 初始化请求对象
            request.Method = "POST";
            request.Timeout = timeOut;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            if (!string.IsNullOrEmpty(refererUrl))
                request.Referer = refererUrl;
            if (cookieContainer != null)
                request.CookieContainer = cookieContainer;
            #endregion

            string boundary = "----" + DateTime.Now.Ticks.ToString("x");//分隔符
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            //请求流
            var postStream = new MemoryStream();
            #region 处理Form表单请求内容
            //是否用Form上传文件
            var formUploadFile = formItems != null && formItems.Count > 0;
            if (formUploadFile)
            {
                //文件数据模板
                string fileFormdataTemplate =
                    "\r\n--" + boundary +
                    "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" +
                    "\r\nContent-Type: application/octet-stream" +
                    "\r\n\r\n";
                //文本数据模板
                string dataFormdataTemplate =
                    "\r\n--" + boundary +
                    "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                    "\r\n\r\n{1}";
                foreach (var item in formItems)
                {
                    string formdata = null;
                    if (item.IsFile)
                    {
                        //上传文件
                        formdata = string.Format(
                            fileFormdataTemplate,
                            item.Key, //表单键
                            item.FileName);
                    }
                    else
                    {
                        //上传文本
                        formdata = string.Format(
                            dataFormdataTemplate,
                            item.Key,
                            item.Value);
                    }

                    //统一处理
                    byte[] formdataBytes = null;
                    //第一行不需要换行
                    if (postStream.Length == 0)
                        formdataBytes = Encoding.UTF8.GetBytes(formdata.Substring(2, formdata.Length - 2));
                    else
                        formdataBytes = Encoding.UTF8.GetBytes(formdata);
                    postStream.Write(formdataBytes, 0, formdataBytes.Length);

                    //写入文件内容
                    if (item.FileContent != null && item.FileContent.Length > 0)
                    {
                        using (var stream = item.FileContent)
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead = 0;
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                postStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                //结尾
                var footer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                postStream.Write(footer, 0, footer.Length);

            }
            else
            {
                request.ContentType = "application/x-www-form-urlencoded";
            }
            #endregion

            request.ContentLength = postStream.Length;

            #region 输入二进制流
            if (postStream != null)
            {
                postStream.Position = 0;
                //直接写入流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                ////debug
                //postStream.Seek(0, SeekOrigin.Begin);
                //StreamReader sr = new StreamReader(postStream);
                //var postStr = sr.ReadToEnd();
                postStream.Close();//关闭文件访问
            }
            #endregion

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (cookieContainer != null)
            {
                response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
            }

            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(responseStream, encoding ?? Encoding.UTF8))
                {
                    string retString = myStreamReader.ReadToEnd();
                    return retString;
                }
            }
        }
    }
}
