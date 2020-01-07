using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DataFactory
    {
        public static List<Category> ListCategory()
        {
            return new List<Category>()
            {
                new Category(){ Name="History", Description = "History" },
                new Category(){ Name="Horror", Description = "Horror" },
                new Category(){ Name="Medical", Description = "Medical" },
                new Category(){ Name="Romance", Description = "Romance" },
                new Category(){ Name="Travel", Description = "Travel" }
            };
        }

        public static List<Book> ListBook(List<Author> authors)
        {
            return new List<Book>()
            {
                new Book(){ Name = "Persepolis", Price = 4.69, Publisher= "Knopf Doubleday Publishing Group", Author = authors[0], Year= new DateTime(2010,10,10), Cover= SaveFileToFolder.SaveImage("persepolis.jpg")},
                new Book(){ Name = "Black Tower", Price = 17.79, Publisher= "HuangGuan", Author = authors[1], Year= new DateTime(2011,10,11), Cover= SaveFileToFolder.SaveImage("blackTower.jpg")},
                new Book(){ Name = "Publication Manual of the American Psychological Association", Price = 4.9, Publisher= "American Psychological Association", Author = authors[2], Year= new DateTime(2012,10,12), Cover= SaveFileToFolder.SaveImage("publicationManualoftheAmericanPsychologicalAssociation.jpg")},
                new Book(){ Name = "City of Bones", Price = 4.79, Publisher= "Simon & Schuster, Incorporated", Author = authors[3], Year= new DateTime(2013,10,13), Cover= SaveFileToFolder.SaveImage("cityOfBones.jpg")},
                new Book(){ Name = "Into the Wild", Price = 4.8, Publisher= "Knopf Doubleday Publishing Group", Author = authors[4], Year= new DateTime(2014,10,14), Cover= SaveFileToFolder.SaveImage("intoTheWild.jpg")}
            };
        }

        public static List<Author> ListAuthor()
        {
            return new List<Author>()
            {
                new Author() { Name = "Marjane Satrapi", Website="marjanesatrapi.com", Birthday=new DateTime(1960,10,11) },
                new Author() { Name = "Stephen King", Website="stephenking.com", Birthday=new DateTime(1960,10,12) },
                new Author() { Name = "American Psychological Association", Website="americanpsychologicalassociation.com", Birthday=new DateTime(1960,10,13) },
                new Author() { Name = "Cassandra Clare", Website="cassandraclare.com", Birthday=new DateTime(1960,10,14) },
                new Author() { Name = "Jon Krakauer", Website="jonkrakauer.com", Birthday=new DateTime(1960,10,15) }
            };
        }
    }
}
