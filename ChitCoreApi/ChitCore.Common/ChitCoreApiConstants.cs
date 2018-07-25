namespace ChitCore.Common.v1
{
    public class ChitCoreApiConstants
    {
        public enum ChitStatus
        {
            New = 1,
            Inprogress = 2,
            Closed = 3
        }

        public enum CustomerStatus
        {
            None = 0,
            New = 1,        // not yet part of any running chits, but interested in future chits
            Active = 2,     // part of one of the running chits
            InActive = 3    // was a customer before, and not part of any current running chits
        }

        public enum UserType
        {
            None = 0,
            ChitPayer = 1,
            ChitAdmin = 2,
            SystemAdmin = 3     // cannot be deleted. There will be a default admin that should be in system by default, using which we can create other users
        }
    }
}
