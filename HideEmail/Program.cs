/*
 * Given a string that has a valid email address, write a function to hide the first part of the email (before the @ sign), 
 * minus the first and last character. For extra credit, 
 * add a flag to hide the second part after the @ sign to 
 * your function excluding the first character and the domain extension.
 *
 */

namespace HideEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "example+test@example.co.uk";
            string editedMail = EditEmail(email, true);
            Console.WriteLine(editedMail);
        }

        public static string EditEmail(string email, bool hideFull)
        {
            char[] emailArr = email.ToCharArray();

            int atIndex = email.IndexOf('@');
            int domainNameDotIndex = email.IndexOf(".", atIndex);

            // Hide if the username is more than two characters
            if (atIndex > 2)
            {
                for (int i = 1; i < atIndex - 1; i++)
                {
                    emailArr[i] = '*';
                }
            }

            // Hide if the domain name is more than one character
            if (hideFull && (domainNameDotIndex - atIndex - 1 > 1))
            {
                for (int i = atIndex + 2; i < domainNameDotIndex; i++)
                {
                    emailArr[i] = '*';
                }
            }

            return new(emailArr);
        }
    }
}