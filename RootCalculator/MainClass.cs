using System;

namespace RootCalculator {

	class MainClass {

		public const double PRECISION = 0.0000001;

		static void Main(string[] args) {
			double num;
			int root;
			Console.WriteLine("Welcome, this program uses Newton's method to calculate roots (square root, cube root, ect.)");

			while (true) {

				// get user input
				while (true) {
					Console.WriteLine("What number would you like to take the root of? (input a decimal number)");
					try {
						num = Convert.ToDouble(Console.ReadLine());
						break;
					} catch {
						Console.WriteLine("Inavlid input, please input a decimal number.");
					}
				}
				while (true) {
					Console.WriteLine("What root would you like to take? (2 for square root, 3 for cube root, any positive integer)");
					try {
						root = Convert.ToInt32(Console.ReadLine());
						break;
					} catch {
						Console.WriteLine("Inavlid input, please input a decimal number.");
					}
				}

				double result = Root(root, num);
				Console.WriteLine(result);

				Console.WriteLine("Go again? (y/n)");
				if (Console.ReadLine().ToLower().StartsWith("n")) break;
			}

			// wait for key press before ending program
			Console.Write("Press any key to close the program");
			Console.ReadKey();
		}

		static double Root(int root, double num) {
			// Newton's method:
			// x_n+1 = x_n - f(x)/f'(x)
			// f(x) = x^root - num
			// f'(x) = (root)x^(root-1)

			// special cases
			if (Math.Abs(num) < PRECISION) return 0.0;

			if (root == 0) return 1.0;

			double xN = num; // start with xN = num
			double xNPlusOne, fX, fPrimeX, precision;

			while (true) {

				// f(x) = x^root - num
				fX = xN;
				for (int i = 1; i < root; i++) {
					fX *= xN;
				}
				fX -= num;

				// f'(x) = (root)x^(root-1)
				fPrimeX = xN;
				for (int i = 1; i < root - 1; i++) {
					fPrimeX *= xN;
				}
				fPrimeX *= root;

				// x_n+1 = x_n - f(x)/f'(x)
				xNPlusOne = xN - fX / fPrimeX;

				// calculate precision

				precision = xNPlusOne;
				for (int i = 1; i < root; i++) {
					precision *= xNPlusOne;
				}
				precision -= num;


				if (Math.Abs(precision) < PRECISION) break;

				xN = xNPlusOne;

			}

			return xNPlusOne;
		}
	}
}