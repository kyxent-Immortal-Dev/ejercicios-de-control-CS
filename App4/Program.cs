using System;
using System.Collections.Generic;

namespace App4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        static void menu()
        {
            while (true)
            {
                Console.WriteLine("\nSeleccione una opcion:");
                Console.WriteLine("1 - Calculadora");
                Console.WriteLine("2 - Acumular resultado");
                Console.WriteLine("3 - Encriptado");
                Console.WriteLine("4 - Calificaciones");
                Console.WriteLine("5 - Sistema de Inventario");
                Console.WriteLine("6 - Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out int op))
                {
                    switch (op)
                    {
                        case 1:
                            calculator();
                            break;
                        case 2:
                            acumulador();
                            break;
                        case 3:
                            encriptado();
                            break;
                        case 4:
                            calificaciones();
                            break;
                        case 5:
                            SystemaInventario();
                            break;
                        case 6:
                            Console.WriteLine("Gracias por usar el programa , hasta pronto");
                            return;
                        default:
                            Console.WriteLine("Opción no valida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada invalida. Intente de nuevo.");
                }
            }
        }

        static void reloadCal()
        {
            Console.WriteLine("\n¿Desea realizar otra operacion?\n1 - Sí\n2 - No (volver al menu principal)");
            if (int.TryParse(Console.ReadLine(), out int op) && op == 1)
                calculator();
        }

        static void calculator()
        {
            while (true)
            {
                Console.WriteLine("\nSeleccione una operacion:");
                Console.WriteLine("1 - Sumar");
                Console.WriteLine("2 - Restar");
                Console.WriteLine("3 - Multiplicar");
                Console.WriteLine("4 - Dividir");
                Console.WriteLine("5 - Volver al menu");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out int op) || op == 5) break;

                Console.Write("Ingrese el primer numero: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingrese el segundo numero: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine($"Resultado: {num1 + num2}");
                        break;
                    case 2:
                        Console.WriteLine($"Resultado: {num1 - num2}");
                        break;
                    case 3:
                        Console.WriteLine($"Resultado: {num1 * num2}");
                        break;
                    case 4:
                        if (num2 != 0)
                            Console.WriteLine($"Resultado: {num1 / num2}");
                        else
                            Console.WriteLine("Error: división por cero.");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }

                reloadCal();
                break;
            }
        }

        static void acumulador()
        {
            Console.Write("¿Cuantos numeros desea ingresar? ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Entrada invalida.");
                return;
            }

            int suma = 0;
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Ingrese el numero {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                    suma += num;
                else
                    Console.WriteLine("Numero invalido, se ignorara.");
            }

            Console.WriteLine($"La suma total es: {suma}");
        }

        static void encriptado()
        {
            string correctPassword = "12345";
            int intentos = 3;

            while (intentos > 0)
            {
                Console.Write("Ingrese su contrasena: ");
                string input = Console.ReadLine();

                if (input == correctPassword)
                {
                    Console.WriteLine("acceso concedido");
                    return;
                }
                else
                {
                    intentos--;
                    Console.WriteLine($"Contrasena incorrecta , Intentos restantes: {intentos}");
                }
            }

            Console.WriteLine("Acceso denegado , Se agotaron los intentos.");
        }

        static void calificaciones()
        {
            Console.Write("¿Cuantas calificaciones desea ingresar? ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Entrada invalida.");
                return;
            }

            double suma = 0;
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Ingrese la calificación #{i + 1} (0 a 10): ");
                if (double.TryParse(Console.ReadLine(), out double nota) && nota >= 0 && nota <= 10)
                {
                    suma += nota;
                }
                else
                {
                    Console.WriteLine("Nota invalida debe estar entre 0 y 10.");
                    i--; 
                }
            }

            double promedio = suma / cantidad;
            Console.WriteLine($"Promedio: {promedio}");


            if (promedio < 6)

                Console.WriteLine("Rendimiento: bajo");

            else if (promedio < 8)

                
                Console.WriteLine("Rendimiento: regular");
            else

                Console.WriteLine("Rendimiento: excelente");
        }

        static void SystemaInventario()
        {
            List<(string nombre, int cantidad, double precio)> productos = new List<(string, int, double)>();

            while (true)
            {
                Console.Write("\nIngrese nombre del producto (o escriba 'fin' para salir): ");
                string nombre = Console.ReadLine();

                if (nombre.ToLower() == "fin") break;

                Console.Write("Ingrese la cantidad: ");

                if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 0)
                {
                    Console.WriteLine("Cantidad invalida");

                    continue;
                }

                Console.Write("Ingrese el precio: ");
                if (!double.TryParse(Console.ReadLine(), out double precio) || precio < 0)
                {
                    Console.WriteLine("Precio inválido.");

                    continue;

                }



                productos.Add((nombre, cantidad, precio));
                Console.WriteLine("Producto agregado.");
            }

            double total = 0;
            Console.WriteLine("\nInventario:");
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.nombre} - Cantidad: {p.cantidad}, Precio: {p.precio}, Subtotal: {p.cantidad * p.precio}");
                total += p.cantidad * p.precio;
            }

            Console.WriteLine($"Total del inventario: {total}");
        }
    }
}
