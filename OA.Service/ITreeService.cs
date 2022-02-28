using System.Collections.Generic;

namespace OA.Service
{
    public interface ITreeService
    {
        List<TDto> GetRecursionForList<TEntity, TDto>(List<TEntity> entities);
    }
}