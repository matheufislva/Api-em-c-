using API_LIVROS.Models;

namespace API_LIVROS.Routes;

public static class ROTA_GET
{
    public static void MapGetRoutes(this WebApplication app)
    {
        List<Livro> livros = new List<Livro>
        {
            new Livro {Id = 1, Titulo = "Dom Casmurro", Autor = "Machado de Assis", AnoPublicacao = 1889},
            new Livro {Id = 2, Titulo = "1984", Autor = "George Orwell", AnoPublicacao = 1949},
            new Livro {Id = 3, Titulo = "O Robbit", Autor = "J.R.R. Tolkien", AnoPublicacao = 1937},
            new Livro {Id = 4, Titulo = "O Ladrão de Raios", Autor = "Rick Riordan", AnoPublicacao = 2005},
            new Livro {Id = 5, Titulo = "O Mar de Monstros", Autor = "Rick Riordan", AnoPublicacao = 2006},
            new Livro {Id = 6, Titulo = "A Maldição do Titã", Autor = "Rick Riordan", AnoPublicacao = 2007},
            new Livro {Id = 7, Titulo = "The Battle of the Labyrinth", Autor = "Rick Riordan", AnoPublicacao = 2008},
            new Livro {Id = 8, Titulo = "O Último Olimpian", Autor = "Rick Riordan", AnoPublicacao = 2009},
            new Livro {Id = 9, Titulo = "O Cálice dos Deuses", Autor = "Rick Riordan", AnoPublicacao = 2023},
            new Livro {Id = 10, Titulo = "Wrath of the Triple Goddess", Autor = "Rick Riordan", AnoPublicacao = 2024},
            new Livro {Id = 11, Titulo = "Drácula", Autor = "Bram Stoker", AnoPublicacao = 1897},
            new Livro {Id = 12, Titulo = "It - A Coisa", Autor = "Stephen King", AnoPublicacao = 1986},
            new Livro {Id = 13, Titulo = "A longa marcha", Autor = "Stephen King", AnoPublicacao = 1979},
            new Livro {Id = 14, Titulo = "A Dança da Morte", Autor = "Stephen King", AnoPublicacao = 1978},
            new Livro {Id = 15, Titulo = "Carrie", Autor = "Stephen King", AnoPublicacao = 1974},
            new Livro {Id = 16, Titulo = "The Shining", Autor = "Stephen King", AnoPublicacao = 1977},
            new Livro {Id = 18, Titulo = "The Stand", Autor = "Stephen King", AnoPublicacao = 1990},
            new Livro {Id = 19, Titulo = "The Dark Tower", Autor = "Stephen King", AnoPublicacao = 1982},
            new Livro {Id = 20, Titulo = "The Green Mile", Autor = "Stephen King", AnoPublicacao = 1996},
            new Livro {Id = 21, Titulo = "A Arte da Guerra", Autor = "Sun Tzu", AnoPublicacao = -500}, //-500 para 500 a.C.
            new Livro {Id = 22, Titulo = "Don Quixote", Autor = "Miguel de Cervantes", AnoPublicacao = 1605},
            new Livro {Id = 23, Titulo = "O pequeno príncipe", Autor = "Antoine de Saint-Exupéry", AnoPublicacao = 1943},
            new Livro {Id = 24, Titulo = "O código da vinci", Autor = "Dan Brown", AnoPublicacao = 2003},
            new Livro {Id = 25, Titulo = "Cinquenta Tons de Cinza", Autor = "E.L. James", AnoPublicacao = 2011}
        };

         /* ROTAS */

         // Rota get raiz
         app.MapGet("/", () => "API de Livros em funcionamento");

         // Rota get - listar todos os livros
         app.MapGet("/api/livros", () => livros);

         //Rota get - buscar por ID
         app.MapGet("/api/livros/{Id}", (int id) =>
         {
             var livro = livros.FirstOrDefault(l => l.Id == id);
             return livro != null ? Results.Ok(livro) : Results.NotFound("Livro não encontrado");         
         });

        // Rota get - buscar por título (consulta exata)
        app.MapGet("/api/livros/titulo/{titulo}", (string titulo) =>
        {
            var livro = livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            return livro != null ? Results.Ok(livro) : Results.NotFound("Livro não encontrado");
        });

         // Rota get - buscar por ano de publicação
        app.MapGet("/api/livros/ano/{ano:int}", (int ano) =>
        {
            var livrosPorAno = livros.Where(l => l.AnoPublicacao == ano).ToList();
            return livrosPorAno.Any() ? Results.Ok(livrosPorAno) : Results.NotFound("Nenhum livro encontrado para este ano");
        });
    }
}