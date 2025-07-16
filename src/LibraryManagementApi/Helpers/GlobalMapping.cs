using AutoMapper;
using LibraryManagementApi.Dtos.Book;
using LibraryManagementApi.Dtos.Genre;
using LibraryManagementApi.Models;
using LibraryManagementApi.Services.Repositories;

namespace LibraryManagementApi.Helpers;
public class GlobalMapping : Profile
{
    public GlobalMapping()
    {
        // Define your mapping configurations here
        // Example: CreateMap<SourceType, DestinationType>();

        CreateMap<Book, BookResponseDto>();
        CreateMap<BookResponseDto, Book>();
        CreateMap<Genre, GenreResponseDto>();
        CreateMap<GenreResponseDto, Genre>();
    }
}
