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

        public Length To(MeasureType newType)
        {
            // по умолчанию новое значение совпадает со старым
            var newValue = this.value;
            // если текущий тип -- это градусы цельсия
            if (this.type == MeasureType.C)
            {
                switch (newType)
                {
                    // если конвертим в метр, то значение не меняем
                    case MeasureType.C:
                        newValue = this.value;
                        break;
                    // если в км.
                    case MeasureType.F:
                        newValue = this.value / ((9 / 5) + 32);
                        break;
                    // если в  а.е.
                    case MeasureType.Ra:
                        newValue = this.value / (1.8 + 491.67);
                        break;
                    // если в парсек
                    case MeasureType.K:
                        newValue = this.value / 273.15;
                        break;
                }
            }
            else if (newType == MeasureType.C) // если новый тип: метр
            {
                switch (this.type)
                {
                    // если конвертим в C, то значение не меняем
                    case MeasureType.C:
                        newValue = this.value;
                        break;
                    // если в F.
                    case MeasureType.F:
                        newValue = this.value * ((9 / 5) + 32);
                        break;
                    // если в  Ra
                    case MeasureType.Ra:
                        newValue = this.value * (1.8 + 491.67);
                        break;
                    // если в K
                    case MeasureType.K:
                        newValue = this.value * 273.15;
                        break;
                }
            }
            else // то есть не в метр и не из метра
            {
                newValue = this.To(MeasureType.C).To(newType).value;
            }
            return new Length(newValue, newType);



        } //тут что-то не то

        public static Length operator +(Length instance1, Length instance2)
        {
            // то есть у текущей длине добавляем число 
            // полученное преобразованием значения второй длины в тип первой длины
            // так как у нас определен operator+(Length instance, double number)
            // то это сработает как ожидается
            return instance1 + instance2.To(instance1.type).value;
        }

        // вычитание двух длин
        public static Length operator -(Length instance1, Length instance2)
        {
            // тут все тоже, только с минусом
            return instance1 - instance2.To(instance1.type).value;
        }
    }
}
