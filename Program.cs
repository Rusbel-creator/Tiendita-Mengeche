namespace Tiendita_Mengeche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tiendita Mengeche");
            Console.WriteLine();

            // Declaración de las listas
            List<string> productos = new List<string> { "Arroz", "Aceite", "Harina", "Pan", "Queso", "Mantequilla" };
            List<double> precios = new List<double> { 40, 25, 45, 10, 35, 15 };

            // Mostrando el menu y que pasaria si el usuario elige opción "x".
            int opcion = 0;

            do
            {
                Console.WriteLine("Menú de opciones");
                Console.WriteLine("Opción 1: Agregar un producto");
                Console.WriteLine("Opción 2: Mostrar todos los productos");
                Console.WriteLine("Opción 3: Buscar un producto");
                Console.WriteLine("Opción 4: Modificar un producto");
                Console.WriteLine("Opción 5: Eliminar un producto");
                Console.WriteLine("Opción 6: Mostrar estadísticas");
                Console.WriteLine("Opción 7: Odernar el inventario");
                Console.WriteLine("Opción 0: Salir");
                Console.WriteLine();
                Console.Write("¿Qué opción deseas elegir? ");
                opcion = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        AgregarProducto(productos, precios);
                        break;

                    case 2:
                        MostrarProductos(productos, precios);
                        break;

                    case 3:
                        BuscarProducto(productos, precios);
                        break;

                    case 4:
                        ModificarProducto(productos, precios);
                        break;

                    case 5:
                        EliminarProducto(productos, precios);
                        break;

                    case 6:
                        MostrarEstadisticas(productos, precios);
                        break;

                    case 7:
                        OrdenarProductos(productos ,precios);
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Esa opción no es valida.");
                        break;
                }
            } while (opcion != 0);
            

            
        }
        // Metodos del programa...

        // Metodo para agregar un producto
        static void AgregarProducto(List<string> productos, List<double> precios)
        {
            Console.Write("Nombre del producto: ");
            string producto = Console.ReadLine();

            Console.Write("Precio del producto: ");
            double precio = Convert.ToDouble(Console.ReadLine());

            if (precio > 0)
            {
                productos.Add(producto);
                precios.Add(precio);
            } 
            else
            {
                Console.WriteLine("Has introducido un precio no valido, vuelvalo a intentar");
            }

            Console.WriteLine();
        }

        // Metodo para mostrar una lista de los productos
        static void MostrarProductos(List<string> productos, List<double> precios)
        {
            for (int i = 0; i < productos.Count; i++)
            {
                Console.WriteLine($"Producto: {productos[i]} - Precio: {precios[i]}");
            }
        }

        // Metodo para buscar un producto en especifico
        static void BuscarProducto(List<string> productos, List<double> precios)
        {

            Console.WriteLine("¿Qué producto quieres buscar?");
            string nombreProducto = Console.ReadLine();

            int indice = productos.IndexOf(nombreProducto);

            if (indice != -1)
            {
                Console.WriteLine("Producto encontrado");
                Console.WriteLine($"Producto: {productos[indice]}");
                Console.WriteLine($"Precio: {precios[indice]}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
                Console.WriteLine();
            }

        }

        // Metodo para modificar un producto ya exitente
        static void ModificarProducto(List<string> productos, List<double> precios)
        {
            Console.WriteLine("Ingresa el nombre del producto que deseas modificar");
            string nombreProducto = Console.ReadLine();

            int indice = productos.IndexOf(nombreProducto);

            if (indice != -1)
            {
                Console.WriteLine("Producto encontrado");
                Console.WriteLine($"Producto: {productos[indice]}");
                Console.WriteLine($"Precio: {precios[indice]}");
                Console.WriteLine();

                Console.Write("Ingrese el nombre del producto a modificar: ");
                string productoModificado = Console.ReadLine();

                Console.Write("Ingrese el precio del producto a modificar");
                int precioModificado = Convert.ToInt32(Console.ReadLine());

                if (precioModificado > 0)
                {
                    productos[indice] = productoModificado;
                    precios[indice] = precioModificado;

                    Console.WriteLine("Producto modificado correctamente");
                }
                else
                {
                    Console.WriteLine("Has introducido un precio no valido, vuelva a intentar");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
        }

        // Metodo para eliminar un producto
        static void EliminarProducto(List<string> productos, List<double> precios)
        {
            Console.WriteLine("¿Qué producto deseas eliminar?");
            string productoAEliminar = Console.ReadLine();

            int indice = productos.IndexOf(productoAEliminar);

            if (indice != -1)
            {
                productos.Remove(productoAEliminar);
                precios.Remove(precios[indice]);
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
        }

        // Metodo para mostrar las estadisticas de los productos
        static void MostrarEstadisticas(List<string> productos, List<double> precios)
        {
            if (productos.Count != 0)
            {
                int TotalProductos = productos.Count;
                double Mayor = precios.Max();
                double Menor = precios.Min();
                double Promedio = precios.Average();

                Console.WriteLine($"La cantidad de productos que hay es: {TotalProductos}");
                Console.WriteLine($"El precio mayor es: {Mayor}");
                Console.WriteLine($"El precio menor es: {Menor}");
                Console.WriteLine($"El promedio es: {Promedio}");
            }
            else
            {
                Console.WriteLine("No hay productos disponibles, no es posible realizar las estadisticas");
            }
            
        }

        // Metodo para ordenar los productos
        static void OrdenarProductos(List<string> productos, List<double> precios)
        {
            var productosOrdenados = productos
                .Select((nombre, indice) => new { Nombre = nombre, Precio = precios[indice] })
                .OrderBy(p => p.Nombre)
                .ToList();

            productos.Clear();
            precios.Clear();

            foreach (var producto in productosOrdenados)
            {
                productos.Add(producto.Nombre);
                precios.Add(producto.Precio);
            }

            Console.WriteLine("Inventario ordenado correctamente.");
        }

    }
}
