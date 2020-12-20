namespace HotelManagement.Converters
{
    public static class GuestInfoConverter
    {
        public static string ConvertPhone(string number)
        {
            string result = "";
            for (int i = 0; i < number.Length; i++)
            {
                switch (i)
                {
                    case 0: result += number[i] + " ("; break;
                    case 3: result += number[i] + ") "; break;
                    case 6: case 8: result += number[i] + "-"; break;
                    default: result += number[i]; break;
                }
            }
            return result;
        }

        public static string ConvertPassport(string number)
        {
            string result = "";
            for (int i = 0; i < number.Length; i++)
            {
                result += number[i];
                if (i == 1 || i == 3) result += " ";
            }
            return result;
        }
    }
}
