using CustomPowerPoint.Data.Models;
using CustomPowerPoint.Data.Repositories;
using CustomPowerPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomPowerPoint.Controllers;

public class HomeController : Controller
{
    private readonly UserRepository _userRepository;
    private readonly PresentationRepository _presentationRepository;

    public HomeController(UserRepository userRepository, PresentationRepository presentationRepository)
    {
        _userRepository = userRepository;
        _presentationRepository = presentationRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Presentations(string nickname)
    {
        if (!string.IsNullOrWhiteSpace(nickname))
        {
            var user = _userRepository.GetByNickname(nickname);
            if (user == null)
            {
                user = new UserData
                {
                    Nickname = nickname
                };
                _userRepository.AddUser(user);
            }
            ViewBag.UserNickname = nickname;
        }
        else
        {
            return RedirectToAction("Index");
        }
        var presentations = _presentationRepository.GetAllPresentations()
            .Select(p => new PresentationViewModel
            {
                Id = p.Id,
                Title = p.Title,
                CreatorNickname = _userRepository.GetNicknameById(p.CreatorId) ?? "Unknown",
                UploadedDate = p.CreatedAt.ToString("dd/MM/yyyy")
            })
            .ToList();

        return View(presentations);
    }

    [HttpPost]
    public IActionResult CreatePresentation(string title, string nickname)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(nickname))
        {
            ModelState.AddModelError("", "Заголовок и никнейм обязательны.");
            return RedirectToAction("Presentations", new { nickname });
        }

        var user = _userRepository.GetByNickname(nickname);
        if (user == null)
        {
            user = new UserData { Nickname = nickname };
            _userRepository.AddUser(user);
        }

        var presentation = new PresentationData
        {
            Title = title,
            CreatorId = user.Id.ToString()
        };

        var defaultSlide = new SlideData
        {
            Order = 1
        };
        presentation.Slides.Add(defaultSlide);

        _presentationRepository.AddPresentation(presentation);

        return RedirectToAction("Presentations", new
        {
            nickname
        });
    }

    public IActionResult PresentationMode(Guid presentationId)
    {
        var presentation = _presentationRepository.GetPresentationById(presentationId);
        if (presentation == null)
        {
            return NotFound();
        }

        var model = new PresentationModeViewModel
        {
            Id = presentation.Id,
            Title = presentation.Title,
            Slides = presentation.Slides
        };

        return View(model);
    }

    public IActionResult Editor(Guid presentationId, string nickname)
    {
        var presentation = _presentationRepository.GetPresentationById(presentationId);
        if (presentation == null)
        {
            return NotFound();
        }

        var model = new PresentationEditorViewModel
        {
            Id = presentation.Id,
            Title = presentation.Title,
            CreatorNickname = _userRepository.GetNicknameById(presentation.CreatorId) ?? "Unknown",
            Slides = presentation.Slides,
            ActiveSlide = presentation.Slides.FirstOrDefault(),
            Users = presentation.Users
        };

        ViewBag.UserNickname = nickname;

        return View(model);
    }

    [HttpPost]
    public IActionResult AddSlide(Guid presentationId)
    {
        var presentation = _presentationRepository.GetPresentationById(presentationId);
        if (presentation == null)
        {
            return NotFound();
        }
        int newOrder = presentation.Slides.Count + 1;
        var newSlide = new SlideData
        {
            Order = newOrder
        };
        presentation.Slides.Add(newSlide);
        _presentationRepository.Update(presentation);

        return RedirectToAction("Editor", new
        {
            presentationId
        });
    }

    [HttpPost]
    public IActionResult DeleteSlide(Guid slideId, Guid presentationId)
    {
        var presentation = _presentationRepository.GetPresentationById(presentationId);
        if (presentation == null)
        {
            return NotFound();
        }

        var slide = presentation.Slides.FirstOrDefault(s => s.Id == slideId);
        if (slide != null)
        {
            presentation.Slides.Remove(slide);
            _presentationRepository.Update(presentation);
        }

        return RedirectToAction("Editor", new
        {
            presentationId
        });
    }

    [HttpPost]
    public IActionResult SaveSlideContent(Guid slideId, string content)
    {
        _presentationRepository.UpdateSlideContent(slideId, content);
        return Ok();
    }
}
