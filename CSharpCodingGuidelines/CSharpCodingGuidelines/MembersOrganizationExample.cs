using System;
using System.Text;

namespace SoftServe.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// Members organization example, including naming conventions
    /// </summary>
    public class MembersOrganizationExample
    {
        private const int PRIVATE_CONSTANT = 1;
        private const string ANOTHER_PRIVATE_CONSTANT = "test";

        private readonly int privateReadonlyField = 0;
        private readonly string anotherPrivateReadonlyField = "test";

        private readonly IAnotherSampleInterface anotherSampleInterface;
        private readonly ISampleInterface sampleInterface;

        private int privateField;
        private string anotherPrivateField;

        private static readonly int privateStaticReadonlyField = 1;
        private static readonly string anotherPrivateStaticReadonlyField = "test";

        private static int privateStaticField;
        private static string anotherPrivateStaticField;

        /// <summary>
        /// The public constant
        /// </summary>
        public const int PUBLIC_CONSTANT = 2;

        /// <summary>
        /// Another public constant
        /// </summary>
        public const string ANOTHER_PUBLIC_CONSTANT = "test";

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMember"/> class.
        /// </summary>
        public MembersOrganizationExample(ISampleInterface sampleInterface,
                                          IAnotherSampleInterface anotherSampleInterface)
        {
            this.sampleInterface = sampleInterface;
            this.anotherSampleInterface = anotherSampleInterface;
        }

        /// <summary>
        /// Gets or sets the protected property.
        /// </summary>
        protected int ProtectedProperty { get; set; }

        /// <summary>
        /// Gets or sets the public property.
        /// </summary>
        public string PublicProperty { get; set; }

        /// <summary>
        /// Gets the public readonly property.
        /// </summary>
        public string PublicReadonlyProperty { get; private set; }

        private void ExecutePrivateMethod()
        {
            PublicEventHappened?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Executes the protected method.
        /// </summary>
        protected void ExecuteProtectedMethod()
        {
            ExecutePrivateMethod();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            PublicReadonlyProperty = "test";
        }

        /// <summary>
        /// Executes the public method.
        /// </summary>
        public void ExecutePublicMethod()
        {
            // use local constants with descriptive names for magic numbers
            const string INTERNAL_CONSTANT = "test";

            // use var if type is obvious
            var stringBuilder = new StringBuilder(INTERNAL_CONSTANT);
            var testObject = stringBuilder as object;

            // use type name if it's not so obvious
            Type type = GetType();

            ExecuteProtectedMethod();
        }

        /// <summary>
        /// Occurs when public event happened.
        /// </summary>
        public event EventHandler PublicEventHappened;
    }
}
