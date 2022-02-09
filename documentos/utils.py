import pandas as pd

# ===============================================================================================================
# DATASET SPLIT
# ===============================================================================================================

def dataset_split(x, y, size_train, size_val, size_test):
	from sklearn.model_selection import train_test_split
	if size_val == 0:
		x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=size_test)
		x_val = pd.DataFrame() # Empty dataframe
		y_val = pd.DataFrame() # Empty dataframe
	else:
		x_val, x_train, y_val, y_train = train_test_split(x, y, test_size=size_train+size_test)
		x_train, x_test, y_train, y_test = train_test_split(x_train, y_train, test_size=size_test/(size_train+size_test))
    
	return x_train, y_train, x_val, y_val, x_test, y_test

# ===============================================================================================================
# REGRESSOR MODEL TRAINING
# ===============================================================================================================

def train_KNN_R ( x_train, y_train, parameters={'n_neighbors':3} ):
	from sklearn.neighbors import KNeighborsRegressor
	regr = KNeighborsRegressor(**parameters)
	regr.fit(x_train, y_train)
	return regr

def train_GBM_R ( x_train, y_train, parameters={'n_estimators':100, 'learning_rate':0.1, 'max_depth':5} ):
	from sklearn.ensemble import GradientBoostingRegressor
	regr = GradientBoostingRegressor(**parameters)
	regr.fit(x_train, y_train)
	return regr

def train_MLPNN_R ( x_train, y_train, parameters={'max_iter':500} ):
	from sklearn.neural_network import MLPRegressor
	regr = MLPRegressor(**parameters)
	regr.fit(x_train, y_train)
	return regr

def train_SVM_R ( x_train, y_train, parameters={} ):
	from sklearn import svm
	regr = svm.SVR(**parameters)
	regr.fit(x_train, y_train)
	return regr

def train_RF_R ( x_train, y_train, parameters={} ):
	from sklearn.ensemble import RandomForestRegressor
	regr = RandomForestRegressor(**parameters)
	regr.fit(x_train, y_train)
	return regr

def train_L_R ( x_train, y_train, parameters={} ):
	from sklearn.linear_model import LinearRegression
	regr = LinearRegression().fit(x_train, y_train)
	regr.fit(x_train, y_train)
	return regr

# ===============================================================================================================
# MODEL EVALUATION
# ===============================================================================================================

def evaluate_R (regr, x, y, x_train, y_train, x_val, y_val, x_test, y_test):

	from sklearn.metrics import mean_absolute_error, mean_squared_error, r2_score, mean_absolute_percentage_error

	results = {'train':{}, 'validation':{}, 'test':{}, 'all':{} }

	# Predictions of train dataset
	y_train_pred = regr.predict(x_train)
	results['train']['MAE'] = mean_absolute_error(y_train, y_train_pred)
	results['train']['MAPE'] = mean_absolute_percentage_error(y_train, y_train_pred)
	results['train']['R2'] = r2_score(y_train, y_train_pred)

	# Predictions of validation dataset
	if len(x_val > 0):
		y_val_pred = regr.predict(x_val)
		results['validation']['MAE'] = mean_absolute_error(y_val, y_val_pred)
		results['validation']['MAPE'] = mean_absolute_percentage_error(y_val, y_val_pred)
		results['validation']['R2'] = r2_score(y_val, y_val_pred)

	# Predictions of test dataset
	y_test_pred = regr.predict(x_test)
	results['test']['MAE'] = mean_absolute_error(y_test, y_test_pred)
	results['test']['MAPE'] = mean_absolute_percentage_error(y_test, y_test_pred)
	results['test']['R2'] = r2_score(y_test, y_test_pred)

	# Prediction of all dataset
	y_pred = regr.predict(x)
	results['all']['MAE'] = mean_absolute_error(y, y_pred)
	results['all']['MAPE'] = mean_absolute_percentage_error(y, y_pred)
	results['all']['R2'] = r2_score(y, y_pred)

	return results