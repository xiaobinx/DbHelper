using Npgsql;
using System.Threading.Tasks;

namespace DbHelper {
    public interface IResultHandler<T> {
        Task<T> Handle(NpgsqlDataReader reader);
    }
}
