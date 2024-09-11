namespace MultiShopWithMicroservice.IdentityServer.Tools
{
    public class GetCheckAppUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
