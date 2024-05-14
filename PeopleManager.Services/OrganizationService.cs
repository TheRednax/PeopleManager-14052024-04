using PeopleManager.Core;
using PeopleManager.Model;

namespace PeopleManager.Services
{
    public class OrganizationService
    {
        private readonly PeopleManagerDbContext _dbContext;

        public OrganizationService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Find
        public IList<Organization> Find()
        {
            return _dbContext.Organizations
                .ToList();
        }

        //Get (by id)
        public Organization? Get(int id)
        {
            return _dbContext.Organizations
                .FirstOrDefault(p => p.Id == id);
        }

        //Create
        public Organization? Create(Organization organization)
        {
            _dbContext.Organizations.Add(organization);
            _dbContext.SaveChanges();

            return organization;
        }

        //Update
        public Organization? Update(int id, Organization organization)
        {
            var dbOrganization = _dbContext.Organizations
                .FirstOrDefault(p => p.Id == id);

            if (dbOrganization is null)
            {
                return null;
            }

            dbOrganization.Name = organization.Name;
            dbOrganization.Description = organization.Description;

            _dbContext.SaveChanges();

            return dbOrganization;
        }

        //Delete
        public void Delete(int id)
        {
            var organization = _dbContext.Organizations
                .FirstOrDefault(p => p.Id == id);

            if (organization is null)
            {
                return;
            }

            _dbContext.Organizations.Remove(organization);
            _dbContext.SaveChanges();
        }

    }
}
