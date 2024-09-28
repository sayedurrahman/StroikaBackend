import useStudentManagement from '../hooks/useStudentManagement';

const AddStudentForm = () => {
    const {
        firstName,
        lastName,
        dob,
        setFirstName,
        setLastName,
        setDob,
        handleAddStudentSubmit,
        handleReset,
    } = useStudentManagement();

    return (
        <div>
            <h2>Add a New Student</h2>
            <form onSubmit={handleAddStudentSubmit}>
                <label>
                    First name:
                    <input
                        value={firstName}
                        onChange={e => setFirstName(e.target.value)}
                    />
                </label>
                <br />
                <label>
                    Last name:
                    <input
                        value={lastName}
                        onChange={e => setLastName(e.target.value)}
                    />
                </label>
                <br />
                <label>
                    Date Of Birth:
                    <input
                        type="date"
                        value={dob}
                        onChange={e => setDob(e.target.value)}
                    />
                </label>
                <br />
                <br />
                <button type="submit">Submit </button>
                <button type="button" onClick={handleReset}>Reset</button>
            </form>
        </div>
    );
}

export default AddStudentForm;