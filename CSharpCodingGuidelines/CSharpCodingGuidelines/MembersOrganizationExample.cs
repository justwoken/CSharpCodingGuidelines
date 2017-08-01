using System;
using System.Text;

namespace Justwoken.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// Members organization example, including naming conventions.
    /// </summary>
    public class MembersOrganizationExample
    {
        private const int PRIVATE_CONSTANT = 1;
        private const string ANOTHER_PRIVATE_CONSTANT = "test";

        private readonly int privateReadonlyField = 0;
        private readonly string anotherPrivateReadonlyField = "test";

        private readonly IForAnotherExample anotherSampleInterface;
        private readonly IForExample<int, string> sampleInterface;

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
        /// Initializes a new instance of the <see cref="MembersOrganizationExample"/> class.
        /// </summary>
        /// <param name="sampleInterface">The sample interface.</param>
        /// <param name="anotherSampleInterface">Another sample interface.</param>
        /// <remarks>
        /// NOTE: please organize input parameters one below another for better readability.
        /// </remarks>
        public MembersOrganizationExample(IForExample<int, string> sampleInterface,
                                          IForAnotherExample anotherSampleInterface)
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

            // NOTE: use var if type is obvious
            // NOTE: don't shorten words like "strBldr"
            var stringBuilder = new StringBuilder(INTERNAL_CONSTANT);

            // NOTE: prefer soft "as" cast over direct cast, then check for null
            var testObject = stringBuilder as object;

            if (testObject != null)
            {
                // use type name if it's not so obvious
                int type = testObject.GetHashCode();
            }
        }

        /// <summary>
        /// Occurs when public event happened.
        /// </summary>
        public event EventHandler PublicEventHappened;
    }
}
