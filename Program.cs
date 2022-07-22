using System.Text.Json.Serialization;

namespace Movies.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // var testGenres = new Faker<Genre>()

            //.StrictMode(true)
            //.RuleFor(g => g.Name, f => f.Lorem.Word());

            // testGenres.Generate();

            //https://jackhiston.com/2017/10/1/how-to-create-bogus-data-in-c/
            //https://github.com/bchavez/Bogus



            /***********************************************/

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers().AddJsonOptions(x =>
                            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
