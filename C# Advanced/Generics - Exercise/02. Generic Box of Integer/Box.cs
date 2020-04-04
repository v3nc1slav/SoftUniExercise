namespace _02._Generic_Box_of_Integer
{
    public class Box<T>
    {
        public T valueOfString;

        public Box()
        {

        }
        public Box(T text)
        {
            this.valueOfString = text;
        }

        public override string ToString()
        {
            return $"{this.valueOfString.GetType().FullName}: {this.valueOfString}";
        }
    }
}
