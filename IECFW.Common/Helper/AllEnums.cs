namespace IECFW.Common.Helper
{
    public enum UserStatusEnum
    {
        Active = 1,
        Disabled = 2,
        Locked = 3,
        PasswordReset = 4,
        Deleted = 5,
        WaitingApproval = 6
    }

    public enum ResponseBaseResultEnum
    {
        Success,
        Error,
        Warning,
        Info
    }

    public enum ActivationStatusEnum
    {
        Active,
        Passive,
        Deleted
    }

    public enum UIMessageTypeEnum
    {
        NoMessage,
        Success,
        Danger,
        Warning
    }
    public enum ExceptionTypeEnum
    {
        Info = 1,
        Warn = 2,
        Error = 3,
        Fattal = 4
    }
}