using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine
{
    /// <summary>
    /// Генератор кода.
    /// </summary>
    public class CodeGenerator
    {
        /// <summary>
        /// Длинна кода.
        /// </summary>
        private int lenght = 5;

        /// <summary>
        /// Длинна кода.
        /// </summary>
        public int Lenght
        {
            get => lenght;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Недопустимая длинна кода.");
                }

                lenght = value;
            }
        }

        /// <summary>
        /// Создание генератора кода.
        /// </summary>
        public CodeGenerator() { }

        /// <summary>
        /// Возвращает сгенерированый код.
        /// </summary>
        /// <returns>Сгенерированый код</returns>
        public string Generate()
        {
            char[] chars = new char[]
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd',
                'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z'
            };

            char[] code = new char[lenght];
            Random random = new Random();

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }

            return new String(code);
        }
    }
}
