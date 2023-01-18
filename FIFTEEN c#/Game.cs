using System;
namespace FIFTEEN
{
    class Game
    {
        int size;
        int[,] map; //матрица
        int space_x, space_y; //координаты пустой клетки 
        static Random rand = new Random();
        public Game(int size) //size - размер нашего поля (4х4)
        { //конструктор
            if (size < 2)
                size = 2;
            if (size > 5)
                size = 5;
            this.size = size;
            map = new int[size, size]; //создаем карту 
        }
        public void start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = coords_to_position(x, y) + 1;
            space_x = size - 1;
            space_y = size - 1;
            map[space_x, space_y] = 0; // свободное место 
        }
        public void shift(int position)
        {
            int x, y;
            position_to_coords(position, out x, out y);
            if (Math.Abs(space_x - x) + Math.Abs(space_y - y) != 1)
                return;
            map[space_x, space_y] = map[x, y];
            map[x, y] = 0;
            space_x = x;
            space_y = y;
        }
        public void shift_random()
        {
            //shift(rand.Next(0, size * size));
            int a = rand.Next(0, 4); //рандомное число от 0 до 4
            int x = space_x; // запоминаем координаты пустой ячейки в x и y
            int y = space_y;
            switch (a)
            {
                case 0:
                    x--;
                    break;
                case 1:
                    x++;
                    break;
                case 2:
                    y--;
                    break;
                case 3:
                    y++;
                    break;
            }
            shift(coords_to_position(x, y));
        }
        //проверка закончена ли игра
        public bool check_numbers()
        {
            if (!(space_x == size - 1 && space_y == size - 1)) //если пустая не в полседней позиции
                return false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (!(x == size - 1 && y == size - 1)) //если не последняя ячейка
                        if (map[x, y] != coords_to_position(x, y) + 1)
                            return false;
            return true;
        }

        public int get_number(int position) //передается номер кнопки 
        {
            int x, y;
            position_to_coords(position, out x, out y);//передаем позицию а получаем координаты
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y]; // получим позицию
        }
        private int coords_to_position(int x, int y)
        {
            if (x < 0)
                x = 0;
            if (x > size - 1)
                x = size - 1;
            if (y < 0)
                y = 0;
            if (y > size - 1)
                y = size - 1;
            return y * size + x;
        }
        private void position_to_coords(int position, out int x, out int y) //два выходных параметра
        {
            if (position < 0)
                position = 0;
            if (position > size * size - 1)
                position = size * size - 1;
            x = position % size;
            y = position / size;
        }
    }
}
