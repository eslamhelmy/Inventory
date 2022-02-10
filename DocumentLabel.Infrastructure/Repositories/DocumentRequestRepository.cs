using DocumentLabel.Domain;
using DocumentLabel.Infrastructure;
using DocumentLabel.Infrastructure.Repositories;


namespace DocumentLabel.Infrastructure.Repositories
{
    public class DocumentRequestRepository : RepositoryBase<DocumentRequest>
       , IDocumentRequestRepository
    {
        public DocumentRequestRepository(DataContext dbContext) : base(dbContext)
        {
        }
       
    }
}
