using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<AdoptionApplication, int, bool> AdoptionApplicationData(){ return new AdoptionApplicationRepo(); }

        public static IRepo<MedicalRecord, int, bool> MedicalRecordData() { return new MedicalRecordRepo(); }

        public static IRepo<Pet, int, bool> PetData() { return new PetRepo(); }

        public static SRepo<string, List<Pet>> SearchData(){ return new PetRepo(); }

        public static  FRepo<string, List<Pet>> FilterData() { return new PetRepo(); }

        public static IRepo<Prescription, int, bool> PrescriptionData() { return new PrescriptionRepo(); }

        public static IRepo<SuccessStory, int, bool> SuccessStoryData() { return new SuccessStoryRepo(); }

        public static IRepo<User, int, bool> UserData() { return new UserRepo(); }

        public static IAuth AuthData() { return new UserRepo(); }

        public static RegValRepo RegValData() { return new UserRepo(); }

        public static IRepo<Vaccination, int, bool> VaccinationData() { return new VaccinationRepo(); }

        public static IRepo<Token, string, Token> TokenData() { return new TokenRepo(); }
    }
}
