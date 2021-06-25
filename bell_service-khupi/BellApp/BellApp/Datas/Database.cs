using BellApp.Models;
using BellApp.Models.Dtos;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BellApp.Datas
{
    public class Database
    {
        static object locker = new object();

        SQLiteConnection _sqlconnection;

        public Database()
        {
            _sqlconnection = DependencyService.Get<IDatabase>().GetConnection();
            _sqlconnection.CreateTable<UsersDto>();
            _sqlconnection.CreateTable<RiskAssessData>();
            _sqlconnection.CreateTable<StepBack>
                (
                
                );
            _sqlconnection.CreateTable<MitigateEliminateControl>();
            _sqlconnection.CreateTable<Proceed>();
            _sqlconnection.CreateTable<TeamMember>();
            _sqlconnection.CreateTable<IdentityAssess>();
            _sqlconnection.CreateTable<IdentityAssessDetail>();
        }
        //Insert Data
        public int Insert(UsersDto user)
        {
            lock (locker)
            {
                return _sqlconnection.Insert(user);
            }
        }

        public void Insert(RiskAssessData _riskAssessData)
        {
            lock (locker)
            {
                _sqlconnection.InsertWithChildren(_riskAssessData);
                //return _sqlconnection.InsertWithChildren(_riskAssessData);
                /*var existingTodoItem = _sqlconnection.Table<RiskAssessData>()
                        .Where(x => x.Id == _riskAssessData.Id)
                        .FirstOrDefault();*/

                /*if (existingTodoItem == null)
                {
                    await _sqlconnection.InsertWithChildrenAsync(item, recursive: true).ConfigureAwait(false);
                }
                else
                {
                    item.Id = existingTodoItem.Id;
                    await _sqlconnection.UpdateWithChildrenAsync(item).ConfigureAwait(false);
                }*/


            }
        }

        public void InsertStepBack(StepBack _stepBack)
        {
            lock (locker)
            {
                _sqlconnection.InsertWithChildren(_stepBack);
                //return _sqlconnection.InsertWithChildren(_riskAssessData);
                /*var existingTodoItem = _sqlconnection.Table<RiskAssessData>()
                        .Where(x => x.Id == _riskAssessData.Id)
                        .FirstOrDefault();*/

                /*if (existingTodoItem == null)
                {
                    await _sqlconnection.InsertWithChildrenAsync(item, recursive: true).ConfigureAwait(false);
                }
                else
                {
                    item.Id = existingTodoItem.Id;
                    await _sqlconnection.UpdateWithChildrenAsync(item).ConfigureAwait(false);
                }*/


            }
        }

        //
        public UsersDto CheckEmail(UsersDto user)
        {
            lock (locker)
            {
                return _sqlconnection.Table<UsersDto>()
                    .Where(t => t.Email == user.Email && t.Email == user.Email)
                    .FirstOrDefault();
            }
            /*return _sqlconnection.Table<UsersDto>()
                .Where(x => x.Email == user.Email && x.Email == user.Email)
                //.FirstOrDefault();
                .FirstOrDefaultAsync();*/
        }

        //Update Data
        public int Update(UsersDto user)
        {
            lock (locker)
            {
                return _sqlconnection.Update(user);
            }
        }

        //Delete Data
        public int Delete(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Delete<UsersDto>(id);
            }
        }

        //GetAll Data
        public IEnumerable<UsersDto> GetAll()
        {
            lock (locker)
            {
                return (from i in _sqlconnection.Table<UsersDto>() select i).ToList();
           
            }
        }

        //GetAll Data
        public IEnumerable<RiskAssessData> GetAllData()
        {
            lock (locker)
            {
               return _sqlconnection.GetAllWithChildren<RiskAssessData>(); ;
            }
        }

        //Get By Id
        public UsersDto Get(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Table<UsersDto>().FirstOrDefault(t => t.Id == id);
            }
        }

        public RiskAssessData GetUserCredentialsData(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Table<RiskAssessData>().FirstOrDefault(t => t.Id == id);
            }
        }

        //Delete All Data
        public int FullDelete()
        {
            lock (locker)
            {
                return _sqlconnection.DeleteAll<UsersDto>();
            }
        }

        public void Dispose()
        {
            _sqlconnection.Dispose();
        }
    }
}
