using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Game21
{
    public class Contact
    {
        public Contact(string firstName, string lastName, int position, params string[] phoneNumbers)
        {
            this.firstName = firstName;
            this.lastName = lastName;

            // Добавление номеров телефона к контакту
            foreach (var phoneNumber in phoneNumbers)
            {
                this.phoneNumbers.Add(formatPhoneNumber(phoneNumber));
            }

            // сделать номер телефона главным
            mainPhoneNumber = phoneNumbers[position];
        }

        public Contact(string firstName, string lastName, string phoneNumbers)
        {
            this.firstName = firstName;
            this.lastName = lastName;

            // Добавление номеров телефона к контакту
            this.phoneNumbers.Add(formatPhoneNumber(phoneNumbers));

            // Сделает её главной
            mainPhoneNumber = phoneNumbers;
        }

        // Вывод информации о контакте
        public void GetInfo()
        {
            Console.WriteLine($"name: {firstName} {lastName}\tmain phone number: {mainPhoneNumber}");
        }

        private void SetMainPhoneNumber(int position)
        {
            mainPhoneNumber = phoneNumbers[position];
        }

        private string formatPhoneNumber(string phoneNumber)
        {
            // 81231234343 | +71231234343 | +7 123123 43-43 | 8 123123 43-43
            string numberPattern = @"(([\+]{1}[7])|8){1}( |)[1-9]{3}( |)[1-9]{3}( |)[1-9]{2}(-|)[1-9]{2}";

            if (!Regex.IsMatch(phoneNumber, numberPattern))
            {
                throw new Exception($"Ошибка в воде номера {phoneNumber}. Введите номер правильно!");
            }

            return phoneNumber;
        }

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string mainPhoneNumber { get; private set; }

        public List<string> phoneNumbers = new List<string>();
    }
}
