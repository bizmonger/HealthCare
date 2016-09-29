module Contact

type PhoneNumber = Phone  of string
type Email =       Email  of string

type ContactInfo = {
    Phone:PhoneNumber
    Email:Email
}