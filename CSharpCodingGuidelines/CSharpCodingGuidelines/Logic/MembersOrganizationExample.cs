using Justwoken.CSharpCodingGuidelines.WpfApp.Interfaces;
using System;
using System.Text;

namespace Justwoken.CSharpCodingGuidelines.WpfApp.Logic
{
    /// <summary>
    /// Members organization example, including naming conventions.
    /// </summary>
    /// <remarks>
    /// TIP: prefer giving descriptive comments over simply copying class name.
    /// </remarks>
    public class MembersOrganizationExample
    {
        private const string ANOTHER_PRIVATE_CONSTANT = "test";
        private const int PRIVATE_CONSTANT = 1;

        private readonly int privateReadonlyField = 0;
        private readonly string anotherPrivateReadonlyField = "test";

        private readonly IForAnotherExample anotherSampleInterface;
        private readonly IForExample<int, string> sampleInterface;

        private string anotherPrivateField;
        private int privateField;

        private static readonly int privateStaticReadonlyField = 1;
        private static readonly string anotherPrivateStaticReadonlyField = "test";

        private static int privateStaticField;
        private static string anotherPrivateStaticField;

        /// <summary>
        /// Another public constant
        /// </summary>
        public const string ANOTHER_PUBLIC_CONSTANT = "test";

        /// <summary>
        /// The public constant
        /// </summary>
        public const int PUBLIC_CONSTANT = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="MembersOrganizationExample"/> class.
        /// </summary>
        /// <param name="sampleInterface">The sample interface.</param>
        /// <param name="anotherSampleInterface">Another sample interface.</param>
        /// <remarks>
        /// TIP: prefer organizing input parameters one below another for better readability.
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
            PublicEventHappened?.Invoke(this,
                                        EventArgs.Empty);
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
            // TIP: prefer using local constants for magic numbers used only in scope of current method
            const string INTERNAL_CONSTANT = "test";

            // TIP: prefer using var if type is obvious
            // TIP: prefer using full words for readability, avoid shortening words like "strBldr"
            var stringBuilder = new StringBuilder(INTERNAL_CONSTANT);

            // TIP: prefer soft "as" cast over direct cast, then check for null
            var testObject = stringBuilder as object;

            if (testObject != null)
            {
                // TIP: prefer using type name for primitives
                int type = testObject.GetHashCode();
            }
        }

        /// <summary>
        /// Occurs when public event happened.
        /// </summary>
        public event EventHandler PublicEventHappened;
    }
}