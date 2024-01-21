using Microsoft.AspNetCore.Mvc;
using Fitness.Classes;
using System.Collections.Generic;
using Fitness.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DietItemController : ControllerBase
{
    private readonly FitnessContext _context;

    public DietItemController(FitnessContext context)
    {
        _context = context;
    }

    // Tukaj dodajte metode za CRUD operacije
}
