namespace BaoCao1.Models
{
    public class ResultModel
    {
        public bool IsSuccess { get; set; }
        public ResultCode Code { get; set; }
        public string Message { get; set; }
        public object? Id { get; set; }
        public object? Object { get; set; }

        public ResultModel(bool isSuccess, ResultCode code, string message, object? id = null, object? obj = null)
        {
            IsSuccess = isSuccess;
            Code = code;
            Message = message;
            Id = id;
            Object = obj;
        }

        public static string BuildMessage(ResultCode code , string? errorMsg = null)
        {
            var msg = string.Empty;
            switch(code)
            {
                case ResultCode.Ok:
                    msg = "Thao tác thành công. ";
                    break;
                case ResultCode.NotOk:
                    msg = "Thao tác không thành công. ";
                    break;
                case ResultCode.Da_ton_tai:
                    msg = "Ghi chú đã tồn tại. ";
                    break;
                case ResultCode.Khong_ton_tai:
                    msg = "Ghi chú không tồn tại. ";
                    break;
                default:
                    msg = "";
                    break;
            }
            return string.IsNullOrEmpty(errorMsg) ? msg : errorMsg;
        }

        public enum ResultCode
        {
            Ok = 0, 
            NotOk = 1,
            Da_ton_tai = 2,
            Khong_ton_tai = 3,
        }

    }
}
