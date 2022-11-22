using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Свой_тип
{
    //internal
    public enum MeasureType { C, F, Ra, K };
    public class Length
    {
        private double value;
        private MeasureType type;

        public Length(double value, MeasureType type) // << и тут тоже заменил string на MeasureType
        {
            this.value = value;
            this.type = type;
        }
        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.C:
                    typeVerbose = "C";
                    break;
                case MeasureType.F:
                    typeVerbose = "F";
                    break;
                case MeasureType.Ra:
                    typeVerbose = "Ra";
                    break;
                case MeasureType.K:
                    typeVerbose = "K";
                    break;
            }
            return String.Format("{0} {1}", this.value, this.type);
        }
        public static Length operator +(Length instance, double number)
        {
            // расчитываем новую значение
            var newValue = instance.value + number;
            // создаем новый экземпляр класса, с новый значением и типом как у меры, к которой число добавляем
            var length = new Length(newValue, instance.type);
            // возвращаем результат
            return length;
        }

        // чтобы можно было добавлять число также слева
        public static Length operator +(double number, Length instance)
        {
            // вызываем с правильным порядком аргументов, то есть сначала длина потом число
            // для такого порядка мы определили оператор выше
            return instance + number;
        }
        // умножение
        public static Length operator *(Length instance, double number)
        {
            // мне лень по три строчки писать, поэтому я сокращаю код до одной строки
            return new Length(instance.value * number, instance.type); ;
        }

        public static Length operator *(double number, Length instance)
        {
            return instance * number;
        }

        // вычитание
        public static Length operator -(Length instance, double number)
        {
            return new Length(instance.value - number, instance.type); ;
        }

        public static Length operator -(double number, Length instance)
        {
            return instance - number;
        }

        // деление
        public static Length operator /(Length instance, double number)
        {
            return new Length(instance.value / number, instance.type); ;
        }

        public static Length operator /(double number, Length instance)
        {
            return instance / number;
        }
    }
}
