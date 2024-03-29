namespace MedicalClinic.Data;

public class PatientService
{
    private readonly HttpClient _httpClient;
    
    public PatientService(string port)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri($"http://localhost:{port}/")
        };
    }
    
    private Patient StripAllWhiteSpaces(Patient patient)
    {
        patient.FirstName = patient.FirstName.Trim();
        patient.LastName = patient.LastName.Trim();
        patient.MiddleName = patient.MiddleName?.Trim();
        patient.Pesel = patient.Pesel.Trim();
        patient.PhoneNumber = patient.PhoneNumber?.Trim();
        patient.Email = patient.Email?.Trim();
        patient.Address.City = patient.Address.City.Trim();
        patient.Address.Street = patient.Address.Street.Trim();
        patient.Address.HouseNumber = patient.Address.HouseNumber.Trim();
        patient.Address.ApartmentNumber = patient.Address.ApartmentNumber?.Trim();
        patient.Address.PostalCode = patient.Address.PostalCode.Trim();
        return patient;
    }
    
    public async Task<List<Patient>> GetPatients()
    {
        var response = await _httpClient.GetAsync("ClientInfo");
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException)
        {
            return new List<Patient>();
        }
        var patients = await response.Content.ReadFromJsonAsync<List<Patient>>();
        return patients ?? new List<Patient>();
    }

    public async Task<bool> AddPatient(Patient patient)
    {
        var response = await _httpClient.PostAsJsonAsync("ClientInfo", StripAllWhiteSpaces(patient));
        return response.IsSuccessStatusCode;
    }
    
    public async Task<bool> UpdatePatient(Patient patient)
    {
        var response = await _httpClient.PutAsJsonAsync($"ClientInfo", StripAllWhiteSpaces(patient));
        return response.IsSuccessStatusCode;
    }
    
    public async Task<bool> DeletePatient(string pesel)
    {
        var response = await _httpClient.DeleteAsync($"ClientInfo/{pesel}");
        return response.IsSuccessStatusCode;
    }
    
    public async Task<Patient?> GetPatient(string pesel)
    {
        var response = await _httpClient.GetAsync($"ClientInfo/{pesel}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Patient>();
    }
    
    public async Task<List<Patient>> GetPatientsByCity(string city)
    {
        var response = await _httpClient.GetAsync($"ClientInfo/City/{city}");
        response.EnsureSuccessStatusCode();
        var patients = await response.Content.ReadFromJsonAsync<List<Patient>>();
        return patients ?? new List<Patient>();
    }
    
    public async Task<List<Patient>> GetPatientsByPostalCode(string postalCode)
    {
        var response = await _httpClient.GetAsync($"ClientInfo/PostalCode/{postalCode}");
        response.EnsureSuccessStatusCode();
        var patients = await response.Content.ReadFromJsonAsync<List<Patient>>();
        return patients ?? new List<Patient>();
    }
    
    public async Task<List<Patient>> GetPatientsByLastName(string lastName)
    {
        var response = await _httpClient.GetAsync($"ClientInfo/LastName/{lastName}");
        response.EnsureSuccessStatusCode();
        var patients = await response.Content.ReadFromJsonAsync<List<Patient>>();
        return patients ?? new List<Patient>();
    }
}