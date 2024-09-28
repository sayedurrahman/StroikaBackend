import { configureStore } from '@reduxjs/toolkit';
import userRoleReducer from '../features/UserRoleSlice';
import studentReducer from '../features/StudentListSlice';
import nationalityReducer from '../features/NationalitySlice';

export const store = configureStore({
    reducer: {
        userRole: userRoleReducer,
        students: studentReducer,
        nationalities: nationalityReducer,
    },
});