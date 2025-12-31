// MohamadReza Panahandeh
// Minimum distance line equation
        Console.Write("Enter the number of points (at least 2 points are needed): ");
        int n;

        if (!int.TryParse(Console.ReadLine(), out n) || n <= 1)
        {
            Console.WriteLine(" Invalid number of points. Must be a positive integer greater than 1.");
            return;
        }

        List<double> X = new List<double>();
        List<double> Y = new List<double>();

        for (int i = 0; i < n; i++)
        {
            bool valid = false;

            while (!valid)
            {
                Console.Write($"Enter coordinates for point {i + 1} as 'x y': ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(" Input is empty. Please try again.");
                    continue;
                }

                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    Console.WriteLine(" Please enter exactly two numbers (x and y) separated by a space, e.g., 2.5 3.1");
                    continue;
                }

                if (double.TryParse(parts[0],  out double x) &&
                    double.TryParse(parts[1],  out double y))
                {
                    X.Add(x);
                    Y.Add(y);
                    valid = true;
                }
                else
                {
                    Console.WriteLine(" Invalid characters entered. Please ensure both inputs are valid numbers.");
                }
            }
        }

        if (n == 2)
        {
            if (X[0] == X[1] && Y[0] == Y[1])
            {
                Console.WriteLine("\n Error: two points cannot have the same coordinates");
                return;
            }
        }

        double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;
        for (int i = 0; i < n; i++)
        {
            sumX += X[i];
            sumY += Y[i];
            sumXY += X[i] * Y[i];
            sumX2 += X[i] * X[i];
        }

        double denominator = n * sumX2 - sumX * sumX;

        if (denominator == 0)
        {
            Console.WriteLine("\n Error : points are forming a vertical line");
            return;
        }
       double a = (n * sumXY - sumX * sumY) / denominator;
       double b = (sumY - a * sumX) / n;

        Console.WriteLine("\n Line Equation:");
        Console.WriteLine($"y = {a:F4}x + {b:F4}");


