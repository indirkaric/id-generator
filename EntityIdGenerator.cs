class EntityIdGenerator 
{

    private string[] CHARS = {
        "A", "B", "C", "D",
        "E", "F", "G", "H",
        "I", "J", "K", "L",
        "M", "N", "O", "P",
        "Q", "R", "S", "U",
        "V", "W", "X", "Y",
        "Z", "0", "1", "2",
        "3", "4", "5", "6",
        "7", "8", "9"};

    private const int MAX_ITERATIONS = 50;

    public const int DEFAULT_ENTITY_ID_SIZE = 7;

    public string generateEntityId(int length, Func<string, bool> checkIfExists) 
    {

        int iteration = 0;
        do {

            if (length == 0 || length > DEFAULT_ENTITY_ID_SIZE) {

                throw new ArgumentException($"Length should not be 0 and bigger than {DEFAULT_ENTITY_ID_SIZE}");
            }
            string id = generateRandomString();
            bool exists = checkIfExists(id);

            if (!exists) {

                return id;

            }

            iteration++;
            
        } while (iteration < MAX_ITERATIONS);

        throw new InvalidOperationException($"Too many iterations ({MAX_ITERATIONS}).");
    }

    private string generateRandomString() 
    {

        String id  = "";
        Random random = new Random();

        for (int i = 0; i < DEFAULT_ENTITY_ID_SIZE; i++) 
        {

            id  += CHARS[random.Next(0, CHARS.Length)];

        }

        return id;
    }
}