using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieFlix.Data;
using MovieFlix.Entities;
using static System.Console;

WriteLine("This is the MovieFlix database");

var builder = Host.CreateApplicationBuilder();
builder.Services.AddDbContext<MovieDbContext>();

var app = builder.Build();
var context = app.Services.GetRequiredService<MovieDbContext>();

// context.Database.EnsureCreated();


if (context.Movies.Any() == false)
{
    List<Movie> addMovies =
    [
        new Movie(){Title = "The Odyssey",Director = "Christoper Nolan",ReleaseYear = 2026,Duration = 173,Rating = 8.0},
        new Movie(){Title = "Model Citizen",Director = "Tag Mendillo",ReleaseYear = 2026,Duration = 93,Rating = 6.8},
        new Movie(){Title = "Hart of the Beast",Director = "David Ayer",ReleaseYear = 2026,Duration = 101,Rating = 7.3},
        new Movie(){Title = "Resident Evil",Director = "Zach Cregger",ReleaseYear = 2026,Duration = 94,Rating = 7.5},
        new Movie(){Title = "Predestination",Director = "Michael Spierig",ReleaseYear = 2014,Duration = 98,Rating = 7.4},
        new Movie(){Title = "Harry Potter och De Vises Sten",Director = "Chris Columbus",ReleaseYear = 2001,Duration = 146,Rating = 7.7},
        new Movie(){Title = "Flight Risk",Director = "Mel Gibson",ReleaseYear = 2025,Duration = 97,Rating = 5.2},
        new Movie(){Title = "21 Bridges",Director = "Brian Kirk",ReleaseYear = 2019,Duration = 95,Rating = 6.7},
        new Movie(){Title = "The Proposal",Director = "Anne Fletcher",ReleaseYear = 2009,Duration = 103,Rating = 6.8},
        new Movie(){Title = "Bridget Jones dagbok",Director = "Sharon Maguire",ReleaseYear = 2001,Duration = 92,Rating = 6.8},
    ];

    await context.Movies.AddRangeAsync(addMovies);
    var affectedRows = await context.SaveChangesAsync();
    WriteLine($"Affected rows: {affectedRows}");
}

// LINQ = Language Integrated Query
// LINQ Queries
// var query = from m in context.Movies
//             select new Movie { Id = m.Id, Title = m.Title, Director = m.Director, ReleaseYear = m.ReleaseYear };

// // query = query.OrderBy(c => c.Title);
// // query = query.OrderBy(c => c.Title).ThenBy(c => c.ReleaseYear);
// query = query.OrderBy(c => c.Title).ThenByDescending(c => c.ReleaseYear);





// // Frågan körs inte förän vi använder ToList();
// var movies = await query.ToListAsync();
// foreach (var movie in movies)
// {
//     WriteLine($"{movie.Id} {movie.Title} {movie.Director} {movie.ReleaseYear}");
// }
// WriteLine("__________________________________________________");
// query = query.Where(c => c.Director == "Zach Cregger");

// var foundMovie = await query.FirstOrDefaultAsync();

// if (foundMovie is not null)
// {
//     WriteLine($"Found Olivers favourite director : {foundMovie.Title}");
// }
// else
// {
//     WriteLine("Kunde inte gitta Olivers favorit regissör");
// }




// // LINQ Methods
// // var found = context.Movies.Find(1);
// // System.Console.WriteLine(found.Title);

// // var movies = await context.Movies
// // .Select(m => new Movie { Id = m.Id, Title = m.Title, Director = m.Director, ReleaseYear = m.ReleaseYear })
// // .ToListAsync(); // Frågan körs här!!!

// var movies = await context.Movies
// .Select(m => new Movie { Id = m.Id, Title = m.Title, Director = m.Director, ReleaseYear = m.ReleaseYear })
// .OrderByDescending(c => c.Title)
// .ToListAsync(); // Frågan körs här!!!

// WriteLine($"Movies in our database: {movies.Count} ");

// foreach (var movie in movies)
// {
//     WriteLine($"Title {movie.Title}");
// }

// var movieCount = await context.Movies.CountAsync(); // Frågan körs här!!!

// WriteLine($"Number of movies in our database {movieCount}");

// var oliversMovie = await context.Movies
//     .Where(c => c.Director == "Zach Cregger")
//     .FirstOrDefaultAsync();

// if (oliversMovie is not null)
// {
//     WriteLine($"Found Olivers movie: {oliversMovie.Title}");
// }

// var foundMovie = await context.Movies
//     .FirstOrDefaultAsync(c => c.Director == "Zach Cregger");

// if (foundMovie is not null)
// {
//     WriteLine($"Found the movie: {foundMovie.Title}");
// }

// var anotherMovie = await context.Movies
//     .SingleOrDefaultAsync(c => c.Director == "Zach Cregger");

// if (anotherMovie is not null)
// {
//     WriteLine($"Found the movie: {anotherMovie.Title}");
// }


// System.Console.WriteLine("_________________________________________");
// // Use pagination...
// var pageResult = await context.Movies.Skip(1).Take(3).ToListAsync();

// foreach (var movie in pageResult)
// {
//     WriteLine($"Title: {movie.Title}");
// }


// /*Lägga till nya filmer */
// // Steg 1. Skapa ett object för filmen
// var newMovie = new Movie()
// {
//     Title = "Mystic River",
//     Director = "Clint Eastwood",
//     ReleaseYear = 2003,
//     Duration = 132,
//     Rating = 7.9
// };

// // Steg 2. Addera fillmen till listan Movies => Lägger till den i ChangTracker för databasen
// await context.Movies.AddAsync(newMovie);

// WriteLine($"Movies in our database: {await context.Movies.CountAsync()}");

// // Steg 3. Spara ner filmen till databasen...
// var numberOfRows = await context.SaveChangesAsync();

// WriteLine($"Movies in our database: {await context.Movies.CountAsync()}, affected rows: {numberOfRows}");

// // Uppdatera film
// Steg 1. Hämta filmen som ska uppdateras 
// var movieToUpdate = await context.Movies.SingleOrDefaultAsync(c => c.Title == "21 Bridges");

// // Steg 2. Uppdatera information i det funn objectet...
// movieToUpdate?.Rating = 8.1;

// bool hasChanges = context.ChangeTracker.HasChanges();

// WriteLine($"Has changes: {hasChanges}");

// // Steg 3. Spara ner till databasen!!!
// if (await context.SaveChangesAsync() > 0)
// {
//     var result = await context.Movies.SingleOrDefaultAsync(c => c.Title == "21 Bridges");
//     WriteLine($"Rating for 21 Bridges {result?.Rating}");

// }
// else
// {
//     WriteLine($"Det gick inte att uppdatera");
// }

/* Radera ett objekt(film) */
// Steg 1. Hämta in de som ska tas bort...
// var movieToRemove = await context.Movies.FindAsync(9);

// // Steg 2. Markera objektet för borttaging...
// context.Movies.Remove(movieToRemove!);

// bool hasChanges = context.ChangeTracker.HasChanges();

// WriteLine($"Has changes: {hasChanges}");

// // Steg 3. Spara förändring till databasen
// if (await context.SaveChangesAsync() > 0)
// {
//     System.Console.WriteLine("De gick bra");
// }
// else
// {
//     System.Console.WriteLine("Gick inte så bra");
// }

// var newmMovie = new Movie() { Title = "The Proposal", Director = "Anne Fletcher", ReleaseYear = 2009, Duration = 103, Rating = 6.8 };

// await context.Movies.AddAsync(newmMovie);

// var movieToUpdate = await context.Movies.FirstOrDefaultAsync(c => c.Title == "21 Bridges");

// movieToUpdate?.Rating = 7.8;


// var movieToRemove = await context.Movies.FindAsync(1);

// if (movieToRemove is not null)
// {
//     context.Movies.Remove(movieToRemove);
// }

// var numberOfRowChanges = await context.SaveChangesAsync();

// WriteLine($"Antal rader som är förändrade: {numberOfRowChanges}");

// var mattD = new Actor() { FirstName = "Matt", LastName = "Damon" };
// var danielR = new Actor() { FirstName = "Daniel", LastName = "RadCliff" };
// var emmaw = new Actor() { FirstName = "Emma", LastName = "Watson" };
// var chadwickB = new Actor() { FirstName = "Chadwick", LastName = "Boseman" };
// var markW = new Actor() { FirstName = "Mark", LastName = "Wahlberg" };
// var SiennaM = new Actor() { FirstName = "Sienna", LastName = "Miller" };

// var odessey = await context.Movies.FirstOrDefaultAsync(c => c.Title == "The Odessey");
// var harrypotter = await context.Movies.FirstOrDefaultAsync(c => c.Title == "Harry Potter och De Vises Sten");
// var bridges = await context.Movies.FirstOrDefaultAsync(c => c.Title == "21 Bridges");
// var flightRisk = await context.Movies.FirstOrDefaultAsync(c => c.Title == "Flight Risk");

// odessey?.Actors.Add(mattD);

// if (harrypotter is not null)
// {
//     harrypotter.Actors.Add(danielR);
//     harrypotter.Actors.Add(emmaw);
// }

// if (bridges is not null)
// {
//     bridges.Actors.Add(chadwickB);
//     bridges.Actors.Add(SiennaM);
// }

// if (flightRisk is not null)
// {
//     flightRisk.Actors.Add(markW);
// }

// if (await context.SaveChangesAsync() > 0)
// {
//     WriteLine("Yeee det funkar");
// }
// else
// {
//     WriteLine("Satan i gatan det funkade inte!");
// }

// var movies = await context.Movies.ToListAsync();
// var movies = await context.Movies.Include(c => c.Actors).ToListAsync();

// foreach (var movie in movies)
// {
//     WriteLine($"Title: {movie.Title}");

//     foreach (var actor in movie.Actors)
//     {
//         WriteLine($"\tActor: {actor.FirstName} {actor.LastName}");
//     }
// }

