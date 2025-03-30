using CustomPowerPoint.Data.Models;
using CustomPowerPoint.Enums;
using Microsoft.EntityFrameworkCore;

namespace CustomPowerPoint.Data.Repositories
{
    public class PresentationRepository : BaseRepository<PresentationData>
    {
        public PresentationRepository(WebDbContext webDbContext) : base(webDbContext)
        {
        }

        public IEnumerable<PresentationData> GetAllPresentations()
        {
            return _dbSet.OrderByDescending(p => p.CreatedAt).ToList();
        }

        public PresentationData? GetPresentationById(Guid id)
        {
            var presentation = _dbSet
                .Include(p => p.Slides)
                .Include(p => p.Users)
                .FirstOrDefault(p => p.Id == id);

            if (presentation != null)
            {
                presentation.Slides = presentation.Slides.OrderBy(s => s.Order).ToList();
            }

            return presentation;
        }

        public Guid AddPresentation(PresentationData presentation)
        {
            return Add(presentation);
        }

        public void AddUserToPresentation(Guid presentationId, UserData user)
        {
            var presentation = Get(presentationId);
            if (presentation != null)
            {
                if (!presentation.Users.Any(u => u.Id == user.Id))
                {
                    presentation.Users.Add(user);
                    _webDbContext.SaveChanges();
                }
            }
        }

        public void RemoveUserFromPresentation(Guid presentationId, Guid userId)
        {
            var presentation = Get(presentationId);
            if (presentation != null)
            {
                var user = presentation.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    presentation.Users.Remove(user);
                    _webDbContext.SaveChanges();
                }
            }
        }

        public void UpdateSlideContent(Guid slideId, string content)
        {
            var slide = _webDbContext.Slides
                .Include(s => s.Elements)
                .FirstOrDefault(s => s.Id == slideId);

            if (slide != null && slide.Elements.Any())
            {
                slide.Elements.First().Content = content;
                _webDbContext.SaveChanges();
            }
        }

        public void SetUserRoleInPresentation(Guid presentationId, Guid userId, string role)
        {
            var presentation = Get(presentationId);
            if (presentation != null)
            {
                var user = presentation.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.Role = role;
                    _webDbContext.SaveChanges();
                }
            }
        }
    }
}
