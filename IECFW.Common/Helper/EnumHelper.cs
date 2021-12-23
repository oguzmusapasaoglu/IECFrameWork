namespace IECFW.Common.Helper
{
    public static class EnumHelper
    {
        public static ActivationStatusEnum ToActivationStatus(this int value)
        {
            return (ActivationStatusEnum)value;
        }

        public static int ToInt(this ActivationStatusEnum value)
        {
            return (int)value;
        }
    }
}
