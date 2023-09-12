using MotoApp;
var stack = new BasicStack<double>();
stack.Push(4.5);
stack.Push(43);
stack.Push(333.6);

double sum = 0.0;

while (stack.Count >0)
{
    double item = stack.Pop();
    Console.WriteLine($"Item: {item}");
    sum += item;
}

var stackString = new BasicStack<string>();
stackString.Push("Company");