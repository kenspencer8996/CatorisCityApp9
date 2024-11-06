using CatorisCityAppNew.Viewmodels;
using CityAppServices.Objects.database;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Objects.Services
{
    internal class PersonService
    {
        PersonRepository repository = new PersonRepository();
        public async Task<List<PersonViewModel>> GetPersonsAsync()
        {
            List<PersonViewModel> results = new List<PersonViewModel>();
            try
            {
                List<PersonEntity> persons;
                persons = await repository.GetPersonsAsync();
                foreach (var item in persons)
                {
                    PersonViewModel pvm = new PersonViewModel();
                    pvm.ToModel(item);
                    results.Add(pvm);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return results;
        }
        public async Task<PersonViewModel> GetPersonbyNameAsync(string name)
        {
            PersonViewModel result = new PersonViewModel();
            try
            {
                PersonEntity person;
                person = await repository.GetPersonbyNameAsync(name);
                result.ToModel(person);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public void UpsertSetting(PersonViewModel Setting)
        {
            PersonEntity personEntity = Setting.GetEntity();
            try
            {
                repository.UpsertPerson(personEntity);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
