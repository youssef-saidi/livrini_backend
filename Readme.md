dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet-aspnet-codegenerator controller --controllerName UserController --controllerNamespace Livrini.Controllers --relativeFolderPath Controllers --model User --dataContext LivriniDbContext --layout /Views/Shared/_Layout.cshtml

dotnet-aspnet-codegenerator controller --controllerName CategoryController --controllerNamespace Livrini.Controllers --relativeFolderPath Controllers --model Category --dataContext LivriniDbContext --layout /Views/Shared/_Layout.cshtml


dotnet-aspnet-codegenerator controller --controllerName DishController --controllerNamespace Livrini.Controllers --relativeFolderPath Controllers --model Dish --dataContext LivriniDbContext --layout /Views/Shared/_Layout.cshtml

dotnet-aspnet-codegenerator controller --controllerName LigneOrderController --controllerNamespace Livrini.Controllers --relativeFolderPath Controllers --model LigneOrder --dataContext LivriniDbContext --layout /Views/Shared/_Layout.cshtml

dotnet-aspnet-codegenerator controller --controllerName OrderController --controllerNamespace Livrini.Controllers --relativeFolderPath Controllers --model Order --dataContext LivriniDbContext --layout /Views/Shared/_Layout.cshtml

dotnet-aspnet-codegenerator controller --controllerName RestaurantController --controllerNamespace Livrini.Controllers --relativeFolderPath Controllers --model Restaurant --dataContext LivriniDbContext --layout /Views/Shared/_Layout.cshtml


<!-- LigneOrder -->