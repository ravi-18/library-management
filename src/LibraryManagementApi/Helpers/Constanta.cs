namespace LibraryManagementApi.Helpers;

public enum ReservationStatus
{
    Pending,
    Fulfilled,
    Cancelled,
    Expired
}

public enum BorrowStatus
{
    Borrowed,
    Returned,
    Overdue
}