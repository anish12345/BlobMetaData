
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=anishstorage786;AccountKey=E0ShJ37KOKnzUF5p5ijvLKigF1Tm02OJPsKQ0UqA+ouiwPZ+LC0oMXt56Ky4Vg0dpaJdwiIA8UT++ASt4lT15Q==;EndpointSuffix=core.windows.net";
string containerName = "anishstorage78692";
await SetBlobMetaData();

await GetMetaData();

async Task SetBlobMetaData()
{

    string blobName = "script.sql";
    BlobClient blobClient = new BlobClient(connectionString, containerName, blobName);

    IDictionary<string, string> metaData = new Dictionary<string, string>();
    metaData.Add("Department", "Logistics");
    metaData.Add("Application", "AppA");

    await blobClient.SetMetadataAsync(metaData);

    Console.WriteLine("Metadata added");
}

async Task GetMetaData()
{
    string blobName = "script.sql";
    BlobClient blobClient = new BlobClient(connectionString, containerName, blobName);
    BlobProperties blobProperties = await blobClient.GetPropertiesAsync();

    foreach (var metaData in blobProperties.Metadata)
    {
        Console.WriteLine("The key is {0}", metaData.Key);
        Console.WriteLine("The value is {0}", metaData.Value);
    }

}
