 
#### Код проекта "Турбаза" практически идеален, за исключением некоторых моментов: 

 - Названия файлов, например _Add_Ecip.cs_: название файла ничего не
   говорит о его содержимом и назначении
 - Тоже самое можно сказать и о названиях  функций и
   переменных ( button1 , button1_Click,kol,br, bw, fs, to, dr,
   dataGridView1...) - было бы не плохо называть
   кнопки в соответствии их назначению
 - __Отсутствуют пользовательские классы и наследование.__ Намного
   удобнее, когда есть продуманная иерархия пользовательских классов,
   вынесенная отдельно от кода представления
 - Часто встречается слишком большая вложенность и цикломатическая
   сложность. Многие места можно было написать более элегантно: 
   ```c#
   private int Search_Table(Arendator_Cl Srh)
   {
            for (int i = 0; i < Arendators.Count; i++)
            {
                if (Arendators[i].Number == Srh.Number)
                {
                    if (Arendators[i].Name == Srh.Name)
                    {
                        if (Arendators[i].Phone == Srh.Phone)
                        {
                            if (Arendators[i].Time_from == Srh.Time_from)
                            {
                                if (Arendators[i].Time_to == Srh.Time_to)
                                {
                                    return i;
                                }
                            }
                        }
                    }
                }
            }
            return -1;
 ```
 - Есть вот такие классы, в которых ничего не происходит: 
  ```
    class Sauna_Arend
    {
        public int Number;
        public DateTime Time_from;
        public DateTime Time_to;
        
        public Sauna_Arend()
        {
            Number = 0;
        }
    }
  ```
  Возможно, их свойства как-то изменяются из вне, что также не
  приветствуется, или он просто используется как структура. 
 - Можно было использовать перечисление, массив или хотя бы switch вместо: 
  ```c#
  private string Month(int num)
  {
            if (num == 1)
                return "Января";
            if (num == 2)
                return "Февраля";
            if (num == 3)
                return "Марта";
            if (num == 4)
                return "Апреля";
            if (num == 5)
                return "Мая";
            if (num == 6)
                return "Июня";
            if (num == 7)
                return "Июля";
            if (num == 8)
                return "Августа";
            if (num == 9)
                return "Сентября";
            if (num == 10)
                return "Октября";
            if (num == 11)
                return "Ноября";
            return "Декабря";
  }
  ```


 В общем и целом тяжеловато просто глядя на код разобраться, что
 происходит. Код не имеет структуры, есть только набор процедур без
 намека на способ их связи между собой. 
