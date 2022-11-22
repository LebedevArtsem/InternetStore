using System.Collections.Generic;

namespace InternetStore.Domain
{
    public class Liked
    {
        public string Id { get; set; }
        
        public User User { get; set; }

        public List<Product> Products { get; set; }

    }
}
