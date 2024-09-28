import { createSlice } from "@reduxjs/toolkit";

// Initial state
const initialState = {
    role: "admin"
};

const userRoleSlice = createSlice({
    name: "userRole",
    initialState,
    reducers: {
        toggleRole: (state) => {
            state.role = state.role === 'admin' ? 'register' : 'admin'
        }
    }
});

// Export actions
export const { toggleRole } = userRoleSlice.actions

// Export reducer
export default userRoleSlice.reducer;